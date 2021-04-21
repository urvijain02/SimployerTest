using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TopicTweets.Data.DataAccesses;
using TopicTweets.Handler.Mappers;
using TopicTweets.Handler.Models;

namespace TopicTweets.Handler.Handlers
{
    public class TweetHandler : ITweetHandler
    {
        private readonly ITweetDataAccess _dataAccess;
        private readonly IMappings _mapper;
        private readonly ILogger<TweetHandler> _logger;

        public TweetHandler(ITweetDataAccess dataAccess, IMappings mapper,
            ILogger<TweetHandler> logger)
        {
            _dataAccess = dataAccess;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<TweetResponse> GetTweetsByTopic(Guid id)
        {
            var tweets = _dataAccess.GetTweetsByTopic(id);
            return tweets == null ? null : tweets.Select(x => _mapper.MapTweetToResponse(x)).ToList();
        }

        public TweetResponse GetTweet(string id)
        {
            var tweet = _dataAccess.GetTweet(id);
            return _mapper.MapTweetToResponse(tweet);
        }
    }
}