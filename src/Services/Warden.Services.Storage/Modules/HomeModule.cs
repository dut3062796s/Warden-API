﻿using Nancy;

namespace Warden.Services.Storage.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => Response.AsJson(new { name = "Warden.Services.Storage" }));
        }
    }
}