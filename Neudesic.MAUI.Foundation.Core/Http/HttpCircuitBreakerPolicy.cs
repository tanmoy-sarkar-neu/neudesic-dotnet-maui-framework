using Neudesic.MAUI.Foundation.Core.Interfaces.Infrastructure;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Net.Http;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpCircuitBreakerPolicy
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
            throw new BrokenCircuitException("Service inoperative. Please try again later");
        }
    }
}