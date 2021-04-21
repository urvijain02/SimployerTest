using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TopicTweets.Data.AppContext;
using TopicTweets.Data.Entities;

namespace TopicTweets.Data.DataAccesses
{
    public class TopicDataAccess : ITopicDataAccess
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TopicDataAccess> _logger;

        public TopicDataAccess(ApplicationDbContext context, ILogger<TopicDataAccess> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            _context.SaveChanges();
        }

        public void DeleteTopic(Guid id)
        {
            var topic = _context.Topics
                .FirstOrDefault(x => x.Id == id);
            if (topic != null)
            {
                _context.Entry(topic)
                    .Collection(t => t.Tweets)
                    .Load();
                _context.RemoveRange(topic.Tweets);
                _context.Remove(topic);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _context.Topics;
        }

        public Topic GetTopic(Guid id)
        {
            return _context.Topics
                .FirstOrDefault(x => x.Id == id);
        }
    }
}