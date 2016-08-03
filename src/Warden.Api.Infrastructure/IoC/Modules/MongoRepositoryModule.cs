﻿using Autofac;
using Warden.Api.Core.Repositories;
using Warden.Api.Infrastructure.Mongo.Repositories;

namespace Warden.Api.Infrastructure.IoC.Modules
{
    public class MongoRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrganizationRepository>()
                .As<IOrganizationRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
        }
    }
}