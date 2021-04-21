using System;
using System.Collections.Generic;
using TopicTweets.Data.Entities;

namespace TopicTweets.Data.DataAccesses
{
    public interface ITopicDataAccess
    {
        void AddTopic(Topic topic);

        void DeleteTopic(Guid id);

        IEnumerable<Topic> GetAllTopics();

        Topic GetTopic(Guid id);
    }
}