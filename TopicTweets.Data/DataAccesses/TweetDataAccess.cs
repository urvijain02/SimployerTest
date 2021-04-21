using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TopicTweets.Data.AppContext;
using TopicTweets.Data.Entities;

namespace TopicTweets.Data.DataAccesses
{
    public class TweetDataAccess : ITweetDataAccess
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TweetDataAccess> _logger;

        public TweetDataAccess(ApplicationDbContext context, ILogger<TweetDataAccess> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Tweet> GetTweetsByTopic(Guid id)
        {
            var topic = _context.Topics
                .FirstOrDefault(x => x.Id == id);
            if (topic == null) return null;
            _context.Entry(topic)
                    .Collection(t => t.Tweets)
                    .Load();
            return topic.Tweets;
        }

        public Tweet GetTweet(string id)
        {
            return _context.Tweets
                .FirstOrDefault(x => x.Id == id);
        }
    }
}