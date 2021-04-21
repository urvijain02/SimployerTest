using TopicTweets.Data.Entities;
using TopicTweets.Handler.Models;

namespace TopicTweets.Handler.Mappers
{
    public class Mappings : IMappings
    {
        public TopicResponse MapTopicToResponse(Topic topic)
        {
            if (topic == null) return null;
            return new TopicResponse
            {
                Id = topic.Id,
                Name = topic.Name,
                Description = topic.Description
            };
        }

        public Topic MapRequestToTopic(TopicRequest topic)
        {
            if (topic == null) return null;
            return new Topic
            {
                Name = topic.Name,
                Description = topic.Description,
            };
        }

        public TweetResponse MapTweetToResponse(Tweet tweet)
        {
            if (tweet == null) return null;
            return new TweetResponse
            {
                Id = tweet.Id,
                Text = tweet.Text
            };
        }

        public Tweet MapSearchToTweet(IntegrationModels.Tweet tweet)
        {
            if (tweet == null) return null;
            return new Tweet
            {
                Id = tweet.Id,
                Text = tweet.Text
            };
        }
    }
}