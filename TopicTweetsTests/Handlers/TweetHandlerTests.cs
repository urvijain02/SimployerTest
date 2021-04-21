using AutoFixture;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TopicTweets.Data.DataAccesses;
using TopicTweets.Data.Entities;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Mappers;
using TopicTweets.Handler.Models;

namespace TopicTweetsTests.Handlers
{
    [TestClass()]
    public class TweetHandlerTests
    {
        private MockRepository _mockRepository;
        private Mock<ITweetDataAccess> _mockTweetDataAccess;
        private Mock<IMappings> _mockMappings;
        private Mock<ILogger<TweetHandler>> _mockLogger;
        private TweetHandler _sut;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockTweetDataAccess = _mockRepository.Create<ITweetDataAccess>();
            _mockMappings = _mockRepository.Create<IMappings>();
            _mockLogger = _mockRepository.Create<ILogger<TweetHandler>>();
            _sut = new TweetHandler(_mockTweetDataAccess.Object,
                _mockMappings.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [TestMethod()]
        public void GetTweetsByTopic_ValidInput_ReturnsTweets()
        {
            // Arrange
            var tweetsData = _fixture.Build<List<Tweet>>()
                            .Create();
            _mockTweetDataAccess.Setup(y => y.GetTweetsByTopic(It.IsAny<Guid>()))
                .Returns(tweetsData);
            _mockMappings.Setup(y => y.MapTweetToResponse(It.IsAny<Tweet>()))
                .Returns(new TweetResponse());

            // Act
            var tweets = _sut.GetTweetsByTopic(It.IsAny<Guid>());

            // Assert
            Assert.IsInstanceOfType(tweets, typeof(IList<TweetResponse>));
            Assert.IsNotNull(tweets);
        }

        [TestMethod()]
        public void GetTweet_ValidInput_ReturnsTweet()
        {
            // Arrange
            var request = _fixture.Build<Tweet>()
                            .Without(x => x.Topics)
                            .Create();
            _mockTweetDataAccess.Setup(y => y.GetTweet(It.IsAny<string>()))
                .Returns(request);
            _mockMappings.Setup(y => y.MapTweetToResponse(It.IsAny<Tweet>()))
                .Returns(new TweetResponse());

            // Act
            var response = _sut.GetTweet(It.IsAny<string>());

            // Assert
            Assert.IsInstanceOfType(response, typeof(TweetResponse));
            Assert.IsNotNull(response);
        }
    }
}