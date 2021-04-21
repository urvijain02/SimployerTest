using TopicTweets.Data.Entities;
using TopicTweets.Handler.Models;

namespace TopicTweets.Handler.Mappers
{
    public interface IMappings
    {
        TopicResponse MapTopicToResponse(Topic topic);

        Topic MapRequestToTopic(TopicRequest topic);

        TweetResponse MapTweetToResponse(Tweet tweet);

        Tweet MapSearchToTweet(IntegrationModels.Tweet tweet);
    }
}