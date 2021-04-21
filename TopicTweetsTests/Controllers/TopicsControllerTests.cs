using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopicTweets.Controllers;
using TopicTweets.Handler.Handlers;
using TopicTweets.Handler.Models;

namespace TopicTweetsTests.Controllers
{
    [TestClass]
    public class TopicsControllerTests
    {
        private MockRepository _mockRepository;
        private Mock<ITopicHandler> _mockTopicHandler;
        private TopicsController _sut;
        private Fixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockTopicHandler = _mockRepository.Create<ITopicHandler>();
            _sut = new TopicsController(_mockTopicHandler.Object);
            _fixture = new Fixture();
        }

        [TestMethod()]
        public void GetTopics_ReturnsTopics()
        {
            // Arrange
            var topicResponse = _fixture.Build<List<TopicResponse>>()
                                .Create();
            _mockTopicHandler.Setup(x => x.GetAllTopics())
                .Returns(() => topicResponse);

            // Act
            var response = _sut.GetTopics();

            // Assert
            Assert.IsInstanceOfType(response, typeof(List<TopicResponse>));
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void GetTopic_ValidInput_ReturnsTopic()
        {
            // Arrange
            var topicResponse = _fixture.Build<TopicResponse>()
                                .Create();
            _mockTopicHandler.Setup(x => x.GetTopic(It.IsAny<Guid>()))
                .Returns(() => topicResponse);

            // Act
            var response = _sut.GetTopic(It.IsAny<Guid>());

            // Assert
            Assert.IsInstanceOfType(response, typeof(TopicResponse));
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public async Task AddTopic_ValidInput_InsertsTopic()
        {
            // Arrange
            _mockTopicHandler.Setup(y => y.AddTopic(It.IsAny<TopicRequest>()));

            // Act
            await _sut.AddTopic(It.IsAny<TopicRequest>());

            // Assert
            _mockTopicHandler.Verify(m => m.AddTopic(It.IsAny<TopicRequest>()));
        }

        [TestMethod()]
        public void RemoveTopic_ValidInput_DeletesTopic()
        {
            // Arrange
            _mockTopicHandler.Setup(y => y.RemoveTopic(It.IsAny<Guid>()));

            // Act
            _sut.RemoveTopic(It.IsAny<Guid>());

            // Assert
            _mockTopicHandler.Verify(m => m.RemoveTopic(It.IsAny<Guid>()));
        }
    }
}