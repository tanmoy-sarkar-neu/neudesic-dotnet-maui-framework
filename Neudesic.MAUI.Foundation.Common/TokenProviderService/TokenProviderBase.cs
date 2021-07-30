using Microsoft.Extensions.Logging;
using Neudesic.MAUI.Foundation.Core.Interfaces.Common.Caching;
using Neudesic.MAUI.Foundation.Core.Interfaces.Common.TokenProvider;
using System;
using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Common.TokenProviderService
{
    /// <summary>
    /// Base class for TokenProvider
    /// </summary>
    public abstract class TokenProviderBase
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly ICacheProvider _cacheProvider;
        private readonly ILogger _logger;

        /// <summary>
        /// Initialize supporting object
        /// </summary>
        /// <param name="tokenProvider"></param>
        /// <param name="cacheProvider"></param>
        /// <param name="logger"></param>
        protected TokenProviderBase(ITokenProvider tokenProvider, ICacheProvider cacheProvider, ILogger logger)
        {
            _tokenProvider = tokenProvider;
            _cacheProvider = cacheProvider;
            _logger = logger;
        }

        /// <summary>
        /// Used this method to get access token using refresh token
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> TrySigninAsync()
        {
            _logger.LogInformation("TrySignin started...");
            try
            {
                var refreshToken = await _tokenProvider.GetRefreshTokenAsync();
                _logger.LogInformation("Successfully retrieved refresh token");

                var accessToken = await _tokenProvider.GetAccessTokenByRefreshTokenAsync(refreshToken);
                _logger.LogInformation("Successfully get access token using refresh token");

                await _cacheProvider.SetValueAsync(_tokenProvider.AccessTokenCacheKey, accessToken);
                _logger.LogInformation($"Successfully persist access token in cache. Key: {_tokenProvider.AccessTokenCacheKey}");

                return true;
            }
            catch (NotImplementedException)
            {
                _logger.LogWarning("GetRefreshToken method not implemented");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return false;
            }
        }
    }
}