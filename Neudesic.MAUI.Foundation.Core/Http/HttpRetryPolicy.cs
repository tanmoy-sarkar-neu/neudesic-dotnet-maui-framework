using Neudesic.MAUI.Foundation.Core.Interfaces.Infrastructure;
using Polly;
using Polly.Retry;
using System;
using System.Net.Http;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpRetryPolicy
    {
        public static AsyncRetryPolicy<HttpResponseMessage> GetHttpRetryPolicy(IRetryPolicyConfig retryPolicyConfig)
        {
            return HttpPolicyBuilder.GetBaseBuilder()
                                          .WaitAndRetryAsync(retryPolicyConfig.RetryCount,
                                                             ComputeDuration);
        }

        private static TimeSpan ComputeDuration(int input)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, input)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
        }
    }
}