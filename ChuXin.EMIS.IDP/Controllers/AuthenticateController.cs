﻿using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using IdentityModel;
using System.Linq;

using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Collections.Generic;

namespace ChuXin.EMIS.IDP.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IWebHostEnvironment _environment;

        public AuthenticateController(
            IIdentityServerInteractionService interaction,
            IWebHostEnvironment environment)
        {
            _interaction = interaction;
            _environment = environment;
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string ReturnUrl { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginRequest request)
        {
            var context = await _interaction.GetAuthorizationContextAsync(request.ReturnUrl);
            var user = Config.GetUsers().First();

            if (user != null && context != null)
            {
                await HttpContext.SignInAsync(user.SubjectId, user.Username);
                return new JsonResult(new { RedirectUrl = request.ReturnUrl, IsOk = true });
            }

            return Unauthorized();
        }

        //[HttpGet]
        //[Route("Logout")]
        //public async Task<IActionResult> Logout(string logoutId)
        //{
        //    var context = await _interaction.GetLogoutContextAsync(logoutId);
        //    bool showSignoutPrompt = true;

        //    if (context?.ShowSignoutPrompt == false)
        //    {
        //        // it's safe to automatically sign-out
        //        showSignoutPrompt = false;
        //    }

        //    if (User?.Identity.IsAuthenticated == true)
        //    {
        //        // delete local authentication cookie
        //        await HttpContext.SignOutAsync();
        //    }

        //    // no external signout supported for now (see \Quickstart\Account\AccountController.cs TriggerExternalSignout)
        //    return Ok(new
        //    {
        //        showSignoutPrompt,
        //        ClientName = string.IsNullOrEmpty(context?.ClientName) ? context?.ClientId : context?.ClientName,
        //        context?.PostLogoutRedirectUri,
        //        context?.SignOutIFrameUrl,
        //        logoutId
        //    });
        //}

        //[HttpGet]
        //[Route("Error")]
        //public async Task<IActionResult> Error(string errorId)
        //{
        //    // retrieve error details from identityserver
        //    var message = await _interaction.GetErrorContextAsync(errorId);

        //    if (message != null)
        //    {
        //        if (!_environment.IsDevelopment())
        //        {
        //            // only show in development
        //            message.ErrorDescription = null;
        //        }
        //    }

        //    return Ok(message);
        //}
    }
}
