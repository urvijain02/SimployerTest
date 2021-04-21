using System;
using System.Collections.Generic;
using TopicTweets.Handler.Models;

namespace TopicTweets.Handler.Handlers
{
    public interface ITweetHandler
    {
        IEnumerable<TweetResponse> GetTweetsByTopic(Guid id);

        TweetResponse GetTweet(string id);
    }
}