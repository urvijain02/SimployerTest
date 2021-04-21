using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Nonpublic engagement metrics for the Tweet at the time of the request.
    /// </summary>
    [DataContract]
    public class TweetNonPublicMetrics
    {
        /// <summary>
        /// Number of times this Tweet has been viewed.
        /// </summary>
        /// <value>Number of times this Tweet has been viewed.</value>
        [DataMember(Name = "impression_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "impression_count")]
        public int? ImpressionCount { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TweetNonPublicMetrics {\n");
            sb.Append("  ImpressionCount: ").Append(ImpressionCount).Append("\n");
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