﻿using System;
using Warden.Common.Queries;

namespace Warden.Api.Core.Queries
{
    public class GetOperation : IAuthenticatedQuery
    {
        public Guid RequestId { get; set; }
        public string UserId { get; set; }
    }
}