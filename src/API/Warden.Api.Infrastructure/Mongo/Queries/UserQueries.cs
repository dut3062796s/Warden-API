﻿using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Warden.Api.Core.Extensions;
using Warden.Api.Core.Domain.Users;

namespace Warden.Api.Infrastructure.Mongo.Queries
{
    public static class UserQueries
    {
        public static IMongoCollection<User> Users(this IMongoDatabase database)
            => database.GetCollection<User>();

        public static async Task<User> GetByIdAsync(this IMongoCollection<User> users,
            Guid id)
        {
            if (id.IsEmpty())
                return null;

            return await users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public static async Task<User> GetByExternalIdAsync(this IMongoCollection<User> users, string externalId)
        {
            if (externalId.Empty())
                return null;

            return await users.AsQueryable().FirstOrDefaultAsync(x => x.ExternalId == externalId);
        }

        public static async Task<User> GetByEmailAsync(this IMongoCollection<User> users, string email)
        {
            if (email.Empty())
                return null;

            return await users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}