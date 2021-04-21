using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TopicTweets.Data.AppContext;
using TopicTweets.Data.DataAccesses;
using TopicTweets.Data.Entities;

namespace TopicTweetsTests.DataAccess
{
    [TestClass()]
    public class TopicDataAccessTests
    {
        private MockRepository _mockRepository;
        private Fixture _fixture;
        private Mock<ILogger<TopicDataAccess>> _mockLogger;
        private ITopicDataAccess _sut;
        const string connectionString = "Data Source=TopicTweetsTests.db";
        private DbContextOptions<ApplicationDbContext> _options;
        private Guid _id = Guid.NewGuid();

        [TestInitialize]
        public void TestInitialize()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connectionString).Options;
            _mockRepository = new MockRepository(MockBehavior.Default);
            _fixture = new Fixture();
            _mockLogger = _mockRepository.Create<ILogger<TopicDataAccess>>();

            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var tweets = new List<Tweet>();
                tweets.Add(new Tweet
                {
                    Id = "123456789",
                    Text = "First tweet text containing searchTopic"
                });
                tweets.Add(new Tweet
                {
                    Id = "987654321",
                    Text = "Second tweet text containing searchTopic"
                });
                context.Topics.Add(new Topic
                {
                    Id = _id,
                    Name = "searchTopic",
                    Description = "Topic description text",
                    Tweets = tweets
                });
                context.SaveChanges();
            }
        }

        [TestMethod()]
        public void GetAllTopics_ReturnsTopics()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TopicDataAccess(context, _mockLogger.Object);

                // Act
                var response = _sut.GetAllTopics();

                // Assert
                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<Topic>));
                Assert.AreEqual(response.Count(), 1);
                Assert.AreEqual(_id, response.First().Id);
                Assert.AreEqual("searchTopic", response.First().Name);
                Assert.AreEqual("Topic description text", response.First().Description);
            }
        }

        [TestMethod()]
        public void GetTopic_ValidInput_ReturnsTopic()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TopicDataAccess(context, _mockLogger.Object);

                // Act
                var response = _sut.GetTopic(_id);

                // Assert
                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(Topic));
                Assert.AreEqual(_id, response.Id);
                Assert.AreEqual("searchTopic", response.Name);
                Assert.AreEqual("Topic description text", response.Description);
            }
        }

        [TestMethod()]
        public void GetTopic_InvalidInput_ReturnsNull()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TopicDataAccess(context, _mockLogger.Object);

                // Act
                var response = _sut.GetTopic(Guid.NewGuid());

                // Assert
                Assert.IsNull(response);
            }
        }

        [TestMethod()]
        public void AddTopic_ValidInput_InsertsTopic()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                var tweets = _fixture.Build<List<Tweet>>()
                                .Create();
                var topicRequest = _fixture.Build<Topic>()
                                    .Without(x => x.Tweets)
                                    .Create();
                topicRequest.Tweets = tweets;

                // Arrange
                _sut = new TopicDataAccess(context, _mockLogger.Object);

                // Act
                _sut.AddTopic(topicRequest);
                var response = _sut.GetAllTopics();

                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(response.Count(), 2);
            }
        }

        [TestMethod()]
        public void DeleteTopic_ValidInput_DeletesTopic()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TopicDataAccess(context, _mockLogger.Object);

                // Act
                _sut.DeleteTopic(_id);
                var response = _sut.GetAllTopics();

                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(response.Count(), 0);
            }
        }

        [TestMethod()]
        public void DeleteTopic_InvalidInput_DeletesTopic()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TopicDataAccess(context, _mockLogger.Object);

                // Act
                _sut.DeleteTopic(Guid.NewGuid());
                var response = _sut.GetAllTopics();

                // Assert
                Assert.IsNotNull(response);
                Assert.AreEqual(response.Count(), 1);
            }
        }
    }
}