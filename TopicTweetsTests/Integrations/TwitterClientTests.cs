using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TopicTweets.Handler.ConfigModels;
using TopicTweets.Handler.IntegrationModels;
using TopicTweets.Handler.Integrations;

namespace TopicTweetsTests.Integrations
{
    [TestClass]
    public class TwitterClientTests
    {
        private MockRepository _mockRepository;
        private Mock<IHttpClientFactory> _mockHttpClientFactory;
        private Mock<ILogger<TwitterClient>> _mockLogger;
        private Mock<IOptions<TwitterSettings>> _mockOptions;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();
            _mockLogger = _mockRepository.Create<ILogger<TwitterClient>>();
            _mockOptions = _mockRepository.Create<IOptions<TwitterSettings>>();
            var client = new HttpClient(new MockHttpMessageHandler());
            _mockHttpClientFactory.Setup(a => a.CreateClient(It.IsAny<string>())).Returns(client);
        }

        private TwitterClient CreateTwitterClient()
        {
            return new TwitterClient(
                _mockHttpClientFactory.Object,
                _mockLogger.Object,
                _mockOptions.Object);
        }

        [TestMethod]
        public async Task TweetsRecentSearch_ValidInput_ReturnsTweets()
        {
            // Arrange
            _mockOptions.Setup(a => a.Value).Returns(new TwitterSettings() { ApiUrl = "http://1url.com", BearerToken = "hxyt" });
            var twitterClient = CreateTwitterClient();
            string query = "topic1";

            // Act
            var result = await twitterClient.TweetsRecentSearch(query);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Data);
            Assert.IsInstanceOfType(result.Data, typeof(List<Tweet>));
        }
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task TweetsRecentSearch_MissingToken_ReturnsUnauthorized()
        {
            // Arrange
            _mockOptions.Setup(a => a.Value).Returns(new TwitterSettings() { ApiUrl = "http://1url.com" });
            var twitterClient = CreateTwitterClient();
            string query = "topic1";

            // Act
            var result = await twitterClient.TweetsRecentSearch(query);
            
        }
    }

    public class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            HttpResponseMessage responseMessage;
            if (string.IsNullOrWhiteSpace(request.Headers.Authorization?.Parameter))
                responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            else
                responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new TweetSearchResponse()
                    {
                        Data = new List<Tweet>()
                        {
                            new Tweet(){ Id="1",Text ="Test1" },
                            new Tweet(){ Id="2",Text ="Test2" },
                        }
                    }))
                };
            return Task.FromResult(responseMessage);
        }
    }
}