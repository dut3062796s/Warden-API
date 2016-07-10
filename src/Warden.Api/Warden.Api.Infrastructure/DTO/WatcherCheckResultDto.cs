﻿using Warden.Api.Core.Domain;

namespace Warden.Api.Infrastructure.DTO
{
    public class WatcherCheckResultDto
    {
        public string WatcherName { get; set; }
        public string WatcherType { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }

        public WatcherCheckResultDto()
        {
        }

        public WatcherCheckResultDto(WatcherCheckResult result)
        {
            WatcherName = result.Watcher.Name;
            WatcherType = result.Watcher.Type.ToString().ToLowerInvariant();
            Description = result.Description;
            IsValid = result.IsValid;
        }
    }
}