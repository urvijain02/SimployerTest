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
    public class TweetDataAccessTests
    {
        private MockRepository _mockRepository;
        private Mock<ILogger<TweetDataAccess>> _mockLogger;
        private ITweetDataAccess _sut;
        const string connectionString = "Data Source=TopicTweetsTests.db";
        private DbContextOptions<ApplicationDbContext> _options;
        private Guid _id = Guid.NewGuid();

        [TestInitialize]
        public void TestInitialize()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connectionString).Options;
            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockLogger = _mockRepository.Create<ILogger<TweetDataAccess>>();
            
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
        public void GetTweetsByTopic_ValidInput_ReturnsTweets()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TweetDataAccess(context, _mockLogger.Object);

                // Act
                var response = _sut.GetTweetsByTopic(_id);
                var resArray = response.ToArray();

                // Assert
                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(IEnumerable<Tweet>));
                Assert.AreEqual(response.Count(), 2);
                Assert.AreEqual("123456789", resArray[0].Id);
                Assert.AreEqual("First tweet text containing searchTopic", resArray[0].Text);
                Assert.AreEqual("987654321", resArray[1].Id);
                Assert.AreEqual("Second tweet text containing searchTopic", resArray[1].Text);
            }
        }

        [TestMethod()]
        public void GetTweetsByTopic_InvalidInput_ReturnsNull()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TweetDataAccess(context, _mockLogger.Object);

                // Act
                var response = _sut.GetTweetsByTopic(Guid.NewGuid());

                // Assert
                Assert.IsNull(response);
            }
        }

        [TestMethod()]
        public void GetTweet_ValidInput_ReturnsTweet()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TweetDataAccess(context, _mockLogger.Object);
                string id = "123456789";

                // Act
                var response = _sut.GetTweet(id);

                // Assert
                Assert.IsNotNull(response);
                Assert.IsInstanceOfType(response, typeof(Tweet));
                Assert.AreEqual("123456789", response.Id);
                Assert.AreEqual("First tweet text containing searchTopic", response.Text);
            }
        }

        [TestMethod()]
        public void GetTweet_InvalidInput_ReturnsNull()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                // Arrange
                _sut = new TweetDataAccess(context, _mockLogger.Object);
                string id = "0000";

                // Act
                var response = _sut.GetTweet(id);

                // Assert
                Assert.IsNull(response);
            }
        }
    }
}