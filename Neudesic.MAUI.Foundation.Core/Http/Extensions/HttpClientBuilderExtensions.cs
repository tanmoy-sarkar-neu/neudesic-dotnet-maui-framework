using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Neudesic.MAUI.Foundation.Core.Interfaces.Infrastructure;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpClientBuilderExtensions
    {
        public static IHttpClientBuilder AddPolicyHandlers(this IHttpClientBuilder httpClientBuilder, string policySectionName, PolicyConfig policyConfig, ILogger logger)
        {
            var circuitBreakerPolicyConfig = (ICircuitBreakerPolicyConfig)policyConfig;
            var retryPolicyConfig = (IRetryPolicyConfig)policyConfig;

            return httpClientBuilder.AddRetryPolicyHandler(retryPolicyConfig)
                                    .AddCircuitBreakerHandler(circuitBreakerPolicyConfig, logger);
        }

        public static IHttpClientBuilder AddRetryPolicyHandler(this IHttpClientBuilder httpClientBuilder, IRetryPolicyConfig retryPolicyConfig)
        {
            return httpClientBuilder.AddPolicyHandler(HttpRetryPolicy.GetHttpRetryPolicy(retryPolicyConfig));
        }

        public static IHttpClientBuilder AddCircuitBreakerHandler(this IHttpClientBuilder httpClientBuilder, ICircuitBreakerPolicyConfig circuitBreakerPolicyConfig, ILogger logger)
        {
            return httpClientBuilder.AddPolicyHandler(HttpCircuitBreakerPolicy.GetHttpCircuitBreakerPolicy(circuitBreakerPolicyConfig, logger));
        }
    }
}