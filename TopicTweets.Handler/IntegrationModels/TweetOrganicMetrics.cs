using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Organic nonpublic engagement metrics for the Tweet at the time of the request.
    /// </summary>
    [DataContract]
    public class TweetOrganicMetrics
    {
        /// <summary>
        /// Number of times this Tweet has been viewed.
        /// </summary>
        /// <value>Number of times this Tweet has been viewed.</value>
        [DataMember(Name = "impression_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "impression_count")]
        public int? ImpressionCount { get; set; }

        /// <summary>
        /// Number of times this Tweet has been Retweeted.
        /// </summary>
        /// <value>Number of times this Tweet has been Retweeted.</value>
        [DataMember(Name = "retweet_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "retweet_count")]
        public int? RetweetCount { get; set; }

        /// <summary>
        /// Number of times this Tweet has been replied to.
        /// </summary>
        /// <value>Number of times this Tweet has been replied to.</value>
        [DataMember(Name = "reply_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reply_count")]
        public int? ReplyCount { get; set; }

        /// <summary>
        /// Number of times this Tweet has been liked.
        /// </summary>
        /// <value>Number of times this Tweet has been liked.</value>
        [DataMember(Name = "like_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "like_count")]
        public int? LikeCount { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TweetOrganicMetrics {\n");
            sb.Append("  ImpressionCount: ").Append(ImpressionCount).Append("\n");
            sb.Append("  RetweetCount: ").Append(RetweetCount).Append("\n");
            sb.Append("  ReplyCount: ").Append(ReplyCount).Append("\n");
            sb.Append("  LikeCount: ").Append(LikeCount).Append("\n");
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