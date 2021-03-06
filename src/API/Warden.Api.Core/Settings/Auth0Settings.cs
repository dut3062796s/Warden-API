﻿namespace Warden.Api.Core.Settings
{
    public class Auth0Settings
    {
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string Connection { get; set; }
        public string CreateUsersToken { get; set; }
        public string ReadUsersToken { get; set; }
    }
}