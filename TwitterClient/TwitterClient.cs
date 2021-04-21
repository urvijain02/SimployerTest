using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TopicTweets.Data.Entities;

namespace TopicTweetsConfigModels
{
    public class TwitterClient: ITwitterClient
    {
        private HttpClient _httpClient;
        private TwitterSettings _twitterSettings;
        private ILogger<TwitterClient> _logger;

        public TwitterClient(HttpClient httpClient,
            ILogger<TwitterClient> logger,
            IOptions<TwitterSettings> twitterSettings)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _twitterSettings = twitterSettings?.Value ?? throw new ArgumentNullException(nameof(twitterSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(twitterSettings));
        }

        public IEnumerable<Tweet> GetTweets(string topicName)
        {
            var tweets = new List<Tweet>();
            tweets.Add(new Tweet {
                Id = "1",
                Text = "test tweet 1",
                Url = "https://www.google.com",
                AuthorId = "abc",
                CreatedAt = new DateTime()
            });
            tweets.Add(new Tweet
            {
                Id = "2",
                Text = "test tweet 2",
                Url = "https://www.google.com",
                AuthorId = "abc",
                CreatedAt = new DateTime()
            });
            tweets.Add(new Tweet
            {
                Id = "3",
                Text = "test tweet 3",
                Url = "https://www.google.com",
                AuthorId = "xyz",
                CreatedAt = new DateTime()
            });
            return tweets;
        }
    }
}
