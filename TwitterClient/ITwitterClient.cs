using System.Collections.Generic;
using TopicTweets.Data.Entities;

namespace TopicTweetsConfigModels
{
    public interface ITwitterClient
    {
        public IEnumerable<Tweet> GetTweets(string topicName);
    }
}
