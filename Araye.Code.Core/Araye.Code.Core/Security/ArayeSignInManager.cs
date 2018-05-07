using Araye.Code.Core.Events;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Araye.Code.Core.Security
{
    public class ArayeSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private readonly IMediator _mediator;

        public ArayeSignInManager(UserManager<TUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<TUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<TUser>> logger,
            IAuthenticationSchemeProvider schemes,
            IMediator mediator)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
            _mediator = mediator;
        }

        public override async Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null)
        {
            var userId = await UserManager.GetUserIdAsync(user);
            await _mediator.Publish(new UserSignedIn { UserId = long.Parse(userId) });
            await base.SignInAsync(user, isPersistent, authenticationMethod);
        }
    }
}
