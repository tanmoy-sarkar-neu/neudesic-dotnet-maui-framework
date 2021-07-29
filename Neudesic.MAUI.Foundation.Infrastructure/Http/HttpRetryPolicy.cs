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

        // Pass logger and customize this method
        private static void OnHttpRetry(DelegateResult<HttpResponseMessage> result, TimeSpan timeSpan, int retryCount)
        {
            if (result.Result != null)
            {
                // logger.LogError("Request failed with {StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}", result.Result.StatusCode, timeSpan, retryCount);
            }
            else
            {
                // logger.LogError("Request failed because network failure. Waiting {timeSpan} before next retry. Retry attempt {retryCount}", timeSpan, retryCount);
            }
        }

        private static TimeSpan ComputeDuration(int input)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, input)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
        }
    }
}
