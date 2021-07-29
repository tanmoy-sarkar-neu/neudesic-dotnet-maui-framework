using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpClientServiceExtensions
    {
        public static void RegisterRemoteService<TRefitContract>(this IServiceCollection services, Uri baseUrl, string policyName = "", PolicyConfig policyConfig = null) where TRefitContract : class
        {
            // TODO: Move all container registration to one method, could be a another service extension Initialize() which needs to be called in Startup.cs before using the framework.
            services.AddTransient<AuthDelegatingHandler>();
            
            var httpClientBuilder = services.AddRefitClient<TRefitContract>()
            .ConfigureHttpClient(client => client.BaseAddress = baseUrl)
            .AddHttpMessageHandler<AuthDelegatingHandler>();
            if (policyConfig != null)
            {
                httpClientBuilder.AddPolicyHandlers(policyName, policyConfig);
            }
        }
    }
}
