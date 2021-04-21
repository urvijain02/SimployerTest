using AutoFixture;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopicTweets.Data.DataAccesses;
using TopicTweets.Data.Entities;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Integrations;
using TopicTweets.Handler.Mappers;
using TopicTweets.Handler.Models;

namespace TopicTweetsTests.Handlers
{
    [TestClass()]
    public class TopicHandlerTests
    {
        private MockRepository _mockRepository;
        private Mock<ITopicDataAccess> _mockTopicDataAccess;
        private Mock<IMappings> _mockMappings;
        private Mock<ITwitterClient> _mockTwitterClient;
        private Mock<ILogger<TopicHandler>> _mockLogger;
        private TopicHandler _sut;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockTopicDataAccess = _mockRepository.Create<ITopicDataAccess>();
            _mockMappings = _mockRepository.Create<IMappings>();
            _mockTwitterClient = _mockRepository.Create<ITwitterClient>();
            _mockLogger = _mockRepository.Create<ILogger<TopicHandler>>();
            _sut = new TopicHandler(_mockTopicDataAccess.Object,
                _mockMappings.Object, _mockTwitterClient.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [TestMethod()]
        public void GetAllTopics_ReturnsTopics()
        {
            // Arrange
            var request = _fixture.Build<List<Topic>>()
                            .Create();
            _mockTopicDataAccess.Setup(y => y.GetAllTopics())
                .Returns(request);
            _mockMappings.Setup(y => y.MapTopicToResponse(It.IsAny<Topic>()))
                .Returns(new TopicResponse());

            // Act
            var response = _sut.GetAllTopics();

            // Assert
            Assert.IsInstanceOfType(response, typeof(IList<TopicResponse>));
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void GetTopic_ValidInput_ReturnsTopic()
        {
            // Arrange
            var request = _fixture.Build<Topic>()
                            .Without(x => x.Tweets)
                            .Create();
            _mockTopicDataAccess.Setup(y => y.GetTopic(It.IsAny<Guid>()))
                .Returns(request);
            _mockMappings.Setup(y => y.MapTopicToResponse(It.IsAny<Topic>()))
                .Returns(new TopicResponse());

            // Act
            var response = _sut.GetTopic(It.IsAny<Guid>());

            // Assert
            Assert.IsInstanceOfType(response, typeof(TopicResponse));
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Id);
        }

        [TestMethod()]
        public async Task AddTopic_ValidInput_InsertsTopic()
        {
            // Arrange
            var request = _fixture.Build<TopicTweets.Handler.IntegrationModels.TweetSearchResponse>()
                            .Create();
            _mockTwitterClient.Setup(y => y.TweetsRecentSearch(It.IsAny<string>()))
                .Returns(Task.FromResult(request));
            _mockMappings.Setup(y => y.MapRequestToTopic(It.IsAny<TopicRequest>()))
                .Returns(new Topic());
            _mockMappings.Setup(y => y.MapSearchToTweet(It.IsAny<TopicTweets.Handler.IntegrationModels.Tweet>()))
                .Returns(new Tweet());
            _mockTopicDataAccess.Setup(y => y.AddTopic(It.IsAny<Topic>()));
            var topicRequest = _fixture.Build<TopicRequest>()
                                .Create();

            // Act
            await _sut.AddTopic(topicRequest);

            // Assert
            _mockTwitterClient.Verify(m => m.TweetsRecentSearch(It.IsAny<string>()));
            _mockTopicDataAccess.Verify(m => m.AddTopic(It.IsAny<Topic>()));
        }

        [TestMethod()]
        public void RemoveTopic_ValidInput_DeletesTopic()
        {
            // Arrange
            _mockTopicDataAccess.Setup(y => y.DeleteTopic(It.IsAny<Guid>()));

            // Act
            _sut.RemoveTopic(It.IsAny<Guid>());

            // Assert
            _mockTopicDataAccess.Verify(m => m.DeleteTopic(It.IsAny<Guid>()));
        }
    }
}