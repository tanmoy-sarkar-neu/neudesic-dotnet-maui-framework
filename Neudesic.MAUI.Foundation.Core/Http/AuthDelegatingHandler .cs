using Neudesic.MAUI.Foundation.Common.TokenProviderService;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Core.Http
{
    public class AuthDelegatingHandler : DelegatingHandler
    {
        private readonly ITokenProvider _tokenProvider;

        public AuthDelegatingHandler(ITokenProvider tokenProvider)
        {
            if (tokenProvider == null)
            {
                //TODO: Means its not implemented or not registered in container. Handle this error
                throw new ArgumentNullException(nameof(tokenProvider), "Contract for IdentityService is not found or its not registered in DI container.");
            }
            this._tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenProvider.GetAccessTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}