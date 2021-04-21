using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TopicTweets.Controllers;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Models;

namespace TopicTweetsTests.Controllers
{
    [TestClass()]
    public class TweetsControllerTests
    {
        private MockRepository _mockRepository;
        private Mock<ITweetHandler> _mockTweetHandler;
        private TweetsController _sut;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockTweetHandler = _mockRepository.Create<ITweetHandler>();
            _sut = new TweetsController(_mockTweetHandler.Object);
            _fixture = new Fixture();
        }

        [TestMethod()]
        public void GetTweetsByTopic_ValidInput_ReturnsTweets()
        {
            // Arrange
            var tweetResponse = _fixture.Build<List<TweetResponse>>()
                               .Create();
            _mockTweetHandler.Setup(x => x.GetTweetsByTopic(It.IsAny<Guid>()))
                .Returns(tweetResponse);

            // Act
            var response = _sut.GetTweetsByTopic(It.IsAny<Guid>());

            // Assert
            Assert.IsInstanceOfType(response, typeof(List<TweetResponse>));
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void GetTweet_ValidInput_ReturnsTweet()
        {
            // Arrange
            var tweetResponse = _fixture.Build<TweetResponse>()
                               .Create();
            _mockTweetHandler.Setup(x => x.GetTweet(It.IsAny<string>()))
                .Returns(tweetResponse);

            // Act
            var response = _sut.GetTweet(It.IsAny<string>());

            // Assert
            Assert.IsInstanceOfType(response, typeof(TweetResponse));
            Assert.IsNotNull(response);
        }
    }
}