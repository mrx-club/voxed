using Core.Data.EF;
using Core.Data.Repositories;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Voxed.WebApp.Constants;
using Voxed.WebApp.Models;

namespace Voxed.WebApp.Controllers;

[Authorize(Roles = nameof(RoleType.Administrator))]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IVoxedRepository _voxedRepository;

    public AdminController(
        IVoxedRepository voxedRepository,
        ILogger<AdminController> logger)
    {
        _logger = logger;
        _voxedRepository = voxedRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<DeleteResponse> Delete([FromForm] DeleteRequest request)
    {
        try
        {
            switch (request.ContentType)
            {
                case ContentType.Comment:

                    var comment = await _voxedRepository.Comments.GetById(new Guid(request.ContentId));
                    if (comment == null) NotFound();
                    comment.State = CommentState.Deleted;
                    await UpdateVoxLastBump(comment);
                    break;

                case ContentType.Vox:

                    var vox = await _voxedRepository.Posts.GetById(new Guid(request.ContentId));
                    if (vox == null) NotFound();
                    vox.State = PostState.Deleted;
                    break;

                default:
                    break;
            }

            await _voxedRepository.SaveChangesAsync();
            return new DeleteResponse() { Value = "OK" };
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
            return new DeleteResponse() { Value = "Error" };
        }
    }

    private async Task UpdateVoxLastBump(Comment comment)
    {
        var vox = await _voxedRepository.Posts.GetById(comment.PostId);
        if (vox == null) return;

        var lastBump = vox.Comments
            .Where(x => x.State == CommentState.Active)
            .OrderByDescending(x => x.CreatedOn)
            .Select(x => x.CreatedOn)
            .FirstOrDefault();

        vox.LastActivityOn = lastBump;
    }
}
