using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpClientServiceExtensions
    {
        public static void RegisterRemoteService<TContract>(this IServiceCollection services, Uri baseUrl, string policyName = "", PolicyConfig policyConfig = null) where TContract : class
        {
            var httpClientBuilder = services.AddRefitClient<TContract>()
            .ConfigureHttpClient(client => client.BaseAddress = baseUrl);
            if (policyConfig != null)
            {
                httpClientBuilder.AddPolicyHandlers(policyName, policyConfig);
            }
        }
    }
}