using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Voxed.WebApp.Extensions;

namespace Voxed.WebApp.Controllers;

public class BaseController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _accessor;

    public BaseController(IHttpContextAccessor accessor, UserManager<User> userManager)
    {
        _accessor = accessor;
        _userManager = userManager;
    }

    protected string UserAgent => Request.Headers.ContainsKey("User-Agent") ? Request.Headers["User-Agent"].ToString() : string.Empty;
    protected string UserIpAddress => HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

    internal async Task<User> CreateAnonymousUser()
    {
        var token = Guid.NewGuid().ToShortString();
        var user = new User
        {
            UserName = Guid.NewGuid().ToShortString(),
            EmailConfirmed = true,
            UserType = UserType.AnonymousAccount,
            IpAddress = UserIpAddress,
            UserAgent = UserAgent,
            Token = token
        };

        var result = await _userManager.CreateAsync(user, token);
        if (result.Succeeded) return user;

        throw new Exception("Error al crear usuario anonimo");
    }
}
