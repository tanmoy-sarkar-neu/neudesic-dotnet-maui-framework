using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Neudesic.MAUI.Foundation.Core.Http;
using Refit;
using System;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpClientServiceExtensions
    {
        public static void RegisterRemoteService<TContract>(this IServiceCollection services, Uri baseUrl, ILogger logger, string policyName = "", PolicyConfig policyConfig = null) where TContract : class
        {
            // TODO: Move all container registration to one method, could be a another service extension Initialize() which needs to be called in Startup.cs before using the framework.
            services.AddTransient<AuthDelegatingHandler>();

            var httpClientBuilder = services.AddRefitClient<TContract>()
            .ConfigureHttpClient(client => client.BaseAddress = baseUrl)
            .AddHttpMessageHandler<AuthDelegatingHandler>();
            if (policyConfig != null)
            {
                httpClientBuilder.AddPolicyHandlers(policyName, policyConfig, logger);
            }
        }
    }
}