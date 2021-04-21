using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopicTweets.Data.DataAccesses;
using TopicTweets.Handler.Integrations;
using TopicTweets.Handler.Mappers;
using TopicTweets.Handler.Models;

namespace TopicTweets.Handler.Handlers
{
    public class TopicHandler : ITopicHandler
    {
        private readonly ITopicDataAccess _dataAccess;
        private readonly ITwitterClient _twitterClient;
        private readonly IMappings _mapper;
        private readonly ILogger<TopicHandler> _logger;

        public TopicHandler(ITopicDataAccess dataAccess, IMappings mapper,
            ITwitterClient twitterClient, ILogger<TopicHandler> logger)
        {
            _dataAccess = dataAccess;
            _twitterClient = twitterClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddTopic(TopicRequest topic)
        {
            var tweets = await _twitterClient.TweetsRecentSearch(topic.Name);
            var topicData = _mapper.MapRequestToTopic(topic);
            var tweetData = tweets.Data.Select(x => _mapper.MapSearchToTweet(x));
            topicData.Tweets = tweetData.ToList();
            _dataAccess.AddTopic(topicData);
        }

        public IEnumerable<TopicResponse> GetAllTopics()
        {
            var topics = _dataAccess.GetAllTopics();
            return topics.Select(x => _mapper.MapTopicToResponse(x)).ToList();
        }

        public TopicResponse GetTopic(Guid id)
        {
            var topic = _dataAccess.GetTopic(id);
            return _mapper.MapTopicToResponse(topic);
        }

        public void RemoveTopic(Guid id)
        {
            _dataAccess.DeleteTopic(id);
        }
    }
}