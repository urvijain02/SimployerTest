using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopicTweets.Handler.Models;

namespace TopicTweets.Handler.Handlers
{
    public interface ITopicHandler
    {
        Task AddTopic(TopicRequest topic);

        IEnumerable<TopicResponse> GetAllTopics();

        TopicResponse GetTopic(Guid id);

        void RemoveTopic(Guid id);
    }
}