﻿using System;
using System.Threading.Tasks;
using Warden.Api.Core.Domain.PaymentPlans;

namespace Warden.Api.Core.Services
{
    public interface IUserFeaturesManager
    {
        Task UseFeatureIfAvailableAsync(string userId, FeatureType feature, Func<Task> action);
    }
}