using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpClientConfigurator
    {
        // Policy COnfig could be a Config json

        public static void RegisterApiService<T>(IServiceCollection services, Uri baseUrl, string policyName = "", PolicyConfig policyConfig = null) where T : class
        {
            var httpClientBuilder = services.AddRefitClient<T>()
            .ConfigureHttpClient(client => client.BaseAddress = baseUrl);
            if (policyConfig != null)
            {
                httpClientBuilder.AddPolicyHandlers(policyName, policyConfig);
            }

        }

    }
}
