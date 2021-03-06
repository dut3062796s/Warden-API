﻿using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Warden.Services.RealTime.Hubs
{
    public class WardenHub : Hub
    {
        //private readonly IUserService _userService;
        //private readonly IWardenService _wardenService;
        private readonly ConcurrentDictionary<string, string> _clients = new ConcurrentDictionary<string, string>();

        //public WardenHub(IUserService userService, IWardenService wardenService)
        //{
        //    _userService = userService;
        //    _wardenService = wardenService;
        //}

        public override async Task OnConnected()
        {
            var groupName = await ValidateClientAndGetGroupNameAsync();
            await Groups.Add(Context.ConnectionId, groupName);
            await base.OnConnected();
        }

        public override async Task OnReconnected()
        {
            var groupName = await ValidateClientAndGetGroupNameAsync();
            await Groups.Add(Context.ConnectionId, groupName);
            await base.OnReconnected();
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            var groupName = RemoveClientAndGetGroupName();
            await Groups.Remove(Context.ConnectionId, groupName);
            await base.OnDisconnected(stopCalled);
        }

        private async Task<string> ValidateClientAndGetGroupNameAsync()
        {
            var accessToken = Context.QueryString["accessToken"];
            var organizationId = Guid.Parse(Context.QueryString["organizationId"]);
            var wardenId = Guid.Parse(Context.QueryString["wardenId"]);
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentException("Empty access token.");
            if (organizationId == Guid.Empty)
                throw new ArgumentException("Empty organization id.");
            if (wardenId == Guid.Empty)
                throw new ArgumentException("Empty warden id.");

            //var user = await _userService.GetByAccessTokenAsync(accessToken);
            //if (user == null || user.State != State.Active)
            //    throw new UnauthorizedAccessException();

            //var hasAccess = await _wardenService.HasAccessAsync(user.Id, organizationId, wardenId);
            //if (!hasAccess)
            //    throw new UnauthorizedAccessException();

            RemoveClientAndGetGroupName();
            var groupName = GetWardenGroupName(organizationId, wardenId);
            _clients.TryAdd(Context.ConnectionId, groupName);

            return groupName;
        }

        private string RemoveClientAndGetGroupName()
        {
            var groupName = "";
            if (_clients.ContainsKey(Context.ConnectionId))
                _clients.TryRemove(Context.ConnectionId, out groupName);

            return groupName;
        }

        private static string GetWardenGroupName(Guid organizationId, Guid wardenId)
            => $"{organizationId:N}:{wardenId:N}";
    }
}