﻿using Neudesic.MAUI.Foundation.Infrastructure.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Infrastructure
{
    public class AuthDelegatingHandler : DelegatingHandler
    {
        private readonly IIdentityService _identityService;
        public AuthDelegatingHandler(IIdentityService identityService)
        {
            if(identityService == null)
            {
                //TODO: Means its not implemented or not registered in container. Handle this error
                throw new ArgumentNullException(nameof(identityService), new Exception("Contract for IdentityService is not found or its not registered in DI container."));
            }

            this._identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // TODO: @Sangeetha GetToken() should handle token expiry, load token from cache if not expired etc. 
            var token = await _identityService.GetToken();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}