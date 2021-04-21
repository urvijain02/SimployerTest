using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TopicTweets.Handler.ConfigModels;
using TopicTweets.Handler.IntegrationModels;

namespace TopicTweets.Handler.Integrations
{
    public class TwitterClient : ITwitterClient
    {
        private IHttpClientFactory _clientFactory;
        private TwitterSettings _twitterSettings;
        private ILogger<TwitterClient> _logger;

        public TwitterClient(IHttpClientFactory clientFactory, ILogger<TwitterClient> logger, IOptions<TwitterSettings> twitterSettings)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _twitterSettings = twitterSettings?.Value ?? throw new ArgumentNullException(nameof(twitterSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(twitterSettings));
        }

        public async Task<TweetSearchResponse> TweetsRecentSearch(string query)
        {
            var param = new Dictionary<string, string>() { { "query", query } };
            string searchUrl = ParseUrl("tweets/search/recent", param);
            var client = _clientFactory.CreateClient(nameof(TwitterClient));
            SetAuthorization(client);
            var httpResponse = await client.GetAsync(searchUrl);
            httpResponse.EnsureSuccessStatusCode();
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TweetSearchResponse>(content);
        }

        private void SetAuthorization(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _twitterSettings.BearerToken);
        }

        private string ParseUrl(string urlpart, Dictionary<string, string> queryParams)
        {
            string uri = string.Format("{0}/{1}", _twitterSettings.ApiUrl.TrimEnd(new char[] { '/' }), urlpart.TrimStart(new char[] { '/' }));
            return QueryHelpers.AddQueryString(uri, queryParams);
        }
    }
}