using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Neudesic.MAUI.Foundation.Core.Http;
using Neudesic.MAUI.Foundation.Core.Interfaces.Common.TokenProvider;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Neudesic.MAUI.Foundation.UnitTest
{
    public class BaseRemoteServiceTest
    {
        private readonly Mock<ITokenProvider> tokenProvider;
        private readonly Mock<AuthDelegatingHandler> handlerMock;
        private readonly Mock<DelegatingHandler> delegateHandlerMock;
        private readonly Mock<ILogger> loggerMock;

        public BaseRemoteServiceTest()
        {
            loggerMock = new Mock<ILogger>();
            tokenProvider = new Mock<ITokenProvider>();
            handlerMock = new Mock<AuthDelegatingHandler>(tokenProvider.Object, loggerMock.Object);
            delegateHandlerMock = new Mock<DelegatingHandler>(handlerMock.Object);
        }

        [Fact]
        public void ShouldCallAtleastOnce()
        {
            handlerMock.Protected().As<IAuthDelegatingHandler>().Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent("test")
                });

            var httpClient = new HttpClient(handlerMock.Object);
            httpClient.BaseAddress = new Uri("http://api.dummy");

            var response = httpClient.GetAsync("/dummy").Result;
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public void ShouldCallDelegateHandlerOnce()
        {
            var httpClient = new HttpClient(delegateHandlerMock.Object);
            httpClient.BaseAddress = new Uri("http://api.dummy");

            httpClient.GetAsync("/dummy");
            delegateHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }

    internal interface IAuthDelegatingHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}