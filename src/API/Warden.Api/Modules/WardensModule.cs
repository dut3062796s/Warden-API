﻿using Nancy;
using Warden.Api.Core.Commands;
using Warden.Api.Core.Services;
using Warden.Common.Commands.Wardens;

namespace Warden.Api.Modules
{
    public class WardensModule : ModuleBase
    {
        public WardensModule(ICommandDispatcher commandDispatcher, 
            IIdentityProvider identityProvider)
            : base(commandDispatcher, identityProvider, modulePath: "organizations/{organizationId}/wardens")
        {
            Post("", async args => await For<RequestNewWarden>()
                .SetResourceId(x => x.WardenId)
                .OnSuccessAccepted("organizations/{organizationId}/wardens/{0}")
                .DispatchAsync());

            Delete("", async args => await For<DeleteWarden>()
                .OnSuccess(HttpStatusCode.NoContent)
                .DispatchAsync());
        }
    }
}