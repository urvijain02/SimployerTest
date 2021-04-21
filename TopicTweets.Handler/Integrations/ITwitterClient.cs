using System.Threading.Tasks;
using TopicTweets.Handler.IntegrationModels;

namespace TopicTweets.Handler.Integrations
{
    public interface ITwitterClient
    {
        Task<TweetSearchResponse> TweetsRecentSearch(string query);
    }
}