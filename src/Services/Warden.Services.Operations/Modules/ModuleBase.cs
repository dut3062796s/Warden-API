﻿using Warden.Services.Nancy;

namespace Warden.Services.Operations.Modules
{
    public abstract class ModuleBase : ApiModuleBase
    {
        protected ModuleBase(string modulePath = "") : base(modulePath)
        {
        }
    }
}