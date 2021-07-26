using Polly;
using Polly.CircuitBreaker;
using System;
using System.Net.Http;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public class HttpCircuitBreakerPolicy
    {
        public static AsyncCircuitBreakerPolicy<HttpResponseMessage> GetHttpCircuitBreakerPolicy(ICircuitBreakerPolicyConfig circuitBreakerPolicyConfig)
        {
            return HttpPolicyBuilder.GetBaseBuilder()
                                      .CircuitBreakerAsync(circuitBreakerPolicyConfig.RetryCount + 1,
                                                           TimeSpan.FromSeconds(circuitBreakerPolicyConfig.BreakDuration),
                                                           (result, breakDuration) =>
                                                           {
                                                               OnHttpBreak(result, breakDuration, circuitBreakerPolicyConfig.RetryCount);
                                                           },
                                                           () =>
                                                           {
                                                               // OnHttpReset(logger);
                                                           });
        }

        public static void OnHttpBreak(DelegateResult<HttpResponseMessage> result, TimeSpan breakDuration, int retryCount)
        {
            //  logger.LogError("Service shutdown during {breakDuration} after {DefaultRetryCount} failed retries.", breakDuration, retryCount);
            throw new BrokenCircuitException("Service inoperative. Please try again later");
        }

        //public static void OnHttpReset(ILogger logger)
        //{
        //    // logger.LogError("Service restarted.");
        //}
    }
}
