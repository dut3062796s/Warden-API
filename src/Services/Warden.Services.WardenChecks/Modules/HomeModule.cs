﻿using Nancy;

namespace Warden.Services.WardenChecks.Modules
{
    public class HomeModule : ModuleBase
    {
        public HomeModule()
        {
            Get("/", args => Response.AsJson(new { name = "Warden.Services.WardenChecks" }));
        }
    }
}