using Polly;
using Polly.Extensions.Http;
using System.Net.Http;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public static class HttpPolicyBuilder
    {
        public static PolicyBuilder<HttpResponseMessage> GetBaseBuilder()
        {
            // this is the base policy builder. On top of this build retry/circuit breaker policy
            // 408 and all server errors 5XX
            return HttpPolicyExtensions.HandleTransientHttpError();
        }
    }
}
