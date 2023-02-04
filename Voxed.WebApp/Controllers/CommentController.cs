using Core.Data.Repositories;
using Core.Entities;
using Core.Services.MediaServices.Models;
using Core.Services.MediaServices;
using Core.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Voxed.WebApp.Extensions;
using Voxed.WebApp.Models;
using Voxed.WebApp.Services;
using static Voxed.WebApp.Models.CommentStickyResponse;
using Core.Services.Avatar;
using Core.Services.TextFormatter;
using Voxed.WebApp.Constants;

namespace Voxed.WebApp.Controllers;

public class CommentController : BaseController
{
    private readonly ILogger<CommentController> _logger;
    private readonly ITextFormatterService _textFormatter;
    private readonly IMediaService _mediaService;
    private readonly IVoxedRepository _voxedRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly INotificationService _notificationService;
    private readonly IServiceScopeFactory _scopeFactory;

    public CommentController(
        ILogger<CommentController> logger,
        INotificationService notificationService,
        ITextFormatterService textFormatter,
        IMediaService mediaService,
        IVoxedRepository voxedRepository,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IHttpContextAccessor accessor,
        IServiceScopeFactory scopeFactory)
        : base(accessor, userManager)
    {
        _textFormatter = textFormatter;
        _mediaService = mediaService;
        _voxedRepository = voxedRepository;
        _userManager = userManager;
        _logger = logger;
        _signInManager = signInManager;
        _notificationService = notificationService;
        _scopeFactory = scopeFactory;
    }

    [HttpPost("comment/nuevo/{id}")]
    public async Task<CreateCommentResponse> Create([FromForm] CreateCommentRequest request, [FromRoute] string id)
    {
        _logger.LogWarning($"{nameof(CreateCommentRequest)} received. " + JsonConvert.SerializeObject(request));

        if (ModelState.IsValid is false)
            return CreateCommentResponse.Failure(ModelState.GetErrorMessage());

        try
        {
            if (request.HasEmptyContent())
                return CreateCommentResponse.Failure("Debes ingresar un contenido");

            var comment = await ProcessComment(request, id);

            _ = Task.Run(() => NotifyCommentCreated(comment, request));

            return CreateCommentResponse.Success(comment.Hash);
        }
        catch (NotImplementedException e)
        {
            _logger.LogWarning(e.ToString());
            return CreateCommentResponse.Failure(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return CreateCommentResponse.Failure("Hubo un error");
        }
    }

    [HttpPost]
    public async Task<CommentStickyResponse> Sticky(CommentStickyRequest request)
    {
        var response = new CommentStickyResponse() { Type = CommentStickyType.CommentSticky };

        try
        {
            var comment = await _voxedRepository.Comments.GetById(request.ContentId);
            if (comment == null) NotFound(response);

            comment.IsSticky = true;
            response.Id = request.ContentId;

            await _voxedRepository.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            _logger.LogError(e.StackTrace);
        }

        return response;
    }

    private async Task NotifyCommentCreated(Comment comment, CreateCommentRequest request)
    {
        using var scope = _scopeFactory.CreateScope();
        var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
        await notificationService.NotifyCommentCreated(comment, request);
        await notificationService.ManageNotifications(comment);
    }

    private async Task<Comment> ProcessComment(CreateCommentRequest request, string id)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            user = await CreateAnonymousUser();
            await _signInManager.SignInAsync(user, true);
            //Crear una notificacion para el nuevo usuario anonimo
        }

        var comment = new Comment()
        {
            Hash = Hash.NewHash(7),
            PostId = GuidExtension.FromShortString(id),
            UserId = user.Id,
            Content = _textFormatter.Format(request.Content),
            Style = AvatarService.GetAvatarStyle(),
            IpAddress = UserIpAddress,
            UserAgent = UserAgent,
            Media = request.HasAttachment() ? await CreateMediaFromRequest(request) : null,
        };

        await _voxedRepository.Comments.Add(comment);

        if (!ContainsHide(comment.Content))
        {
            var vox = await _voxedRepository.Posts.GetById(comment.PostId);
            vox.LastActivityOn = DateTimeOffset.Now;
        }

        await _voxedRepository.SaveChangesAsync();
        return comment;
    }

    private static bool ContainsHide(string content) => 
        content is not null && content.ToLower().Contains(Commands.Hide);

    private async Task<Media> CreateMediaFromRequest(CreateCommentRequest request)
    {
        if (request.GetVoxedAttachment() == null && request.File == null) return null;

        var mediaRequest = new CreateMediaRequest()
        {
            Extension = request.GetVoxedAttachment().Extension,
            ExtensionData = request.GetVoxedAttachment().ExtensionData,
            File = request.File
        };

        return await _mediaService.CreateMedia(mediaRequest);
    }
}