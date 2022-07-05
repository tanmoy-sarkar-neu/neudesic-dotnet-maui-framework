using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Neudesic.MAUI.Foundation.Common.TokenProviderService;
using Neudesic.MAUI.Foundation.Core.Http;
using Neudesic.MAUI.Foundation.Core.Interfaces.Common.Caching;
using Neudesic.MAUI.Foundation.Core.Interfaces.Common.TokenProvider;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Neudesic.MAUI.Foundation.UnitTest
{
    internal class TokenProvider : TokenProviderBase
    {
        public TokenProvider(ITokenProvider tokenProvider, ICacheProvider cacheProvider, ILogger logger) : base(tokenProvider, cacheProvider, logger)
        {
        }
    }

    public class TokenProviderTest
    {
        private readonly Mock<ITokenProvider> tokenProviderMock;
        private readonly Mock<ICacheProvider> cacheProviderMock;
        private readonly Mock<ILogger> loggerMock;

        public TokenProviderTest()
        {
            tokenProviderMock = new Mock<ITokenProvider>();
            cacheProviderMock = new Mock<ICacheProvider>();
            loggerMock = new Mock<ILogger>();
        }

        [Fact]
        public async Task ShouldReturnTrueAsync()
        {
            tokenProviderMock.Setup(x => x.GetAccessTokenAsync()).ReturnsAsync("refreshToken");
            tokenProviderMock.Setup(x => x.GetAccessTokenByRefreshTokenAsync("refreshToken")).ReturnsAsync("accessToken");
            tokenProviderMock.Setup(x => x.AccessTokenCacheKey).Returns("AccessKey");
            cacheProviderMock.Setup(x => x.SetValueAsync<string>(tokenProviderMock.Object.AccessTokenCacheKey, "accessToken"));
            TokenProvider tokenProvider = new TokenProvider(tokenProviderMock.Object, cacheProviderMock.Object, loggerMock.Object);
            Assert.True(await tokenProvider.TrySigninAsync());
        }

        [Fact]
        public async Task ShouldReturnFalseAsync()
        {
            tokenProviderMock.Setup(x => x.GetAccessTokenAsync()).ReturnsAsync("refreshToken");
            tokenProviderMock.Setup(x => x.GetAccessTokenByRefreshTokenAsync("refreshToken")).ReturnsAsync("accessToken");
            tokenProviderMock.Setup(x => x.AccessTokenCacheKey).Returns(String.Empty);
            cacheProviderMock.Setup(x => x.SetValueAsync(tokenProviderMock.Object.AccessTokenCacheKey, "accessToken"));
            TokenProvider tokenProvider = new TokenProvider(tokenProviderMock.Object, cacheProviderMock.Object, loggerMock.Object);
            Assert.False(await tokenProvider.TrySigninAsync());
        }

        [Fact]
        public async Task ShouldReturnNotImplementedExceptionAsync()
        {
            tokenProviderMock.Setup(x => x.GetAccessTokenAsync()).ReturnsAsync("refreshToken");
            tokenProviderMock.Setup(x => x.AccessTokenCacheKey).Returns(String.Empty);
            cacheProviderMock.Setup(x => x.SetValueAsync(tokenProviderMock.Object.AccessTokenCacheKey, "accessToken"));
            TokenProvider tokenProvider = new TokenProvider(tokenProviderMock.Object, cacheProviderMock.Object, loggerMock.Object);
            Assert.False(await tokenProvider.TrySigninAsync());
        }
    }
}