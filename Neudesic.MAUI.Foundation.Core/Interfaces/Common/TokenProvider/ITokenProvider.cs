using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neudesic.MAUI.Foundation.Core.Interfaces.Common.TokenProvider
{
    public interface ITokenProvider
    {
        public string AccessTokenCacheKey { get; }

        Task<string> GetAccessTokenAsync();

        Task<bool> PersistTokenAsync();

        Task<string> GetRefreshTokenAsync();

        Task<bool> PersistRefershTokenAsync();

        /// <summary>
        /// Get AccessToken using refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<string> GetAccessTokenByRefreshTokenAsync(string refreshToken);
    }
}