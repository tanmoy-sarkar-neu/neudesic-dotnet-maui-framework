using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpClientServiceExtensions
    {
        public static void RegisterRemoteService<TRefitContract>(this IServiceCollection services, Uri baseUrl, string policyName = "", PolicyConfig policyConfig = null) where TRefitContract : class
        {           
            var httpClientBuilder = services.AddRefitClient<TRefitContract>()
            .ConfigureHttpClient(client => client.BaseAddress = baseUrl);
            if (policyConfig != null)
            {
                httpClientBuilder.AddPolicyHandlers(policyName, policyConfig);
            }
        }
    }
}
