using System;
using System.Collections.Generic;
using TopicTweets.Data.Entities;

namespace TopicTweets.Data.DataAccesses
{
    public interface ITweetDataAccess
    {
        IEnumerable<Tweet> GetTweetsByTopic(Guid id);

        Tweet GetTweet(string id);
    }
}