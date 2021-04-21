using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// A list of metrics for this user
    /// </summary>
    [DataContract]
    public class UserPublicMetrics
    {
        /// <summary>
        /// Number of users who are following this user.
        /// </summary>
        /// <value>Number of users who are following this user.</value>
        [DataMember(Name = "followers_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "followers_count")]
        public int? FollowersCount { get; set; }

        /// <summary>
        /// Number of users this user is following.
        /// </summary>
        /// <value>Number of users this user is following.</value>
        [DataMember(Name = "following_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "following_count")]
        public int? FollowingCount { get; set; }

        /// <summary>
        /// The number of Tweets (including Retweets) posted by this user.
        /// </summary>
        /// <value>The number of Tweets (including Retweets) posted by this user.</value>
        [DataMember(Name = "tweet_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tweet_count")]
        public int? TweetCount { get; set; }

        /// <summary>
        /// The number of lists that include this user.
        /// </summary>
        /// <value>The number of lists that include this user.</value>
        [DataMember(Name = "listed_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "listed_count")]
        public int? ListedCount { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserPublicMetrics {\n");
            sb.Append("  FollowersCount: ").Append(FollowersCount).Append("\n");
            sb.Append("  FollowingCount: ").Append(FollowingCount).Append("\n");
            sb.Append("  TweetCount: ").Append(TweetCount).Append("\n");
            sb.Append("  ListedCount: ").Append(ListedCount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}