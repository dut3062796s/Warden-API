﻿using Nancy;
using Warden.Api.Core.Commands;
using Warden.Api.Core.Services;
using Warden.Common.Commands.WardenChecks;

namespace Warden.Api.Modules
{
    public class WardenChecksModule : ModuleBase
    {
        public WardenChecksModule(ICommandDispatcher commandDispatcher,
            IIdentityProvider identityProvider)
            : base(commandDispatcher, identityProvider,
                modulePath: "organizations/{organizationId}/wardens/{wardenId}/checks")
        {
            Post("", async args => await For<RequestWardenCheckResultProcessing>()
                .SetResourceId(x => x.ResultId)
                .OnSuccessAccepted("organizations/{organizationId}/wardens/{wardenId}/checks/{0}")
                .DispatchAsync());
        }
    }
}