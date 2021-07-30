using Microsoft.Extensions.Logging;
using Neudesic.MAUI.Foundation.Core.Interfaces.Common.TokenProvider;
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
        private readonly ILogger _logger;

        public AuthDelegatingHandler(ITokenProvider tokenProvider, ILogger logger)
        {
            _logger = logger;
            if (tokenProvider == null)
            {
                _logger.LogError("Contract for IdentityService is not found or its not registered in DI container.");
                //TODO: Means its not implemented or not registered in container. Handle this error
                throw new ArgumentNullException(nameof(tokenProvider), "Contract for IdentityService is not found or its not registered in DI container.");
            }
            this._tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("SendAsync method started...");
            var token = await _tokenProvider.GetAccessTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}