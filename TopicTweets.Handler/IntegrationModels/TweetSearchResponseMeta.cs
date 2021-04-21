using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    ///
    /// </summary>
    [DataContract]
    public class TweetSearchResponseMeta
    {
        /// <summary>
        /// Most recent Tweet Id returned by search query
        /// </summary>
        /// <value>Most recent Tweet Id returned by search query</value>
        [DataMember(Name = "newest_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "newest_id")]
        public string NewestId { get; set; }

        /// <summary>
        /// Oldest Tweet Id returned by search query
        /// </summary>
        /// <value>Oldest Tweet Id returned by search query</value>
        [DataMember(Name = "oldest_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "oldest_id")]
        public string OldestId { get; set; }

        /// <summary>
        /// This value is used to get the next 'page' of results by providing it to the next_token parameter.
        /// </summary>
        /// <value>This value is used to get the next 'page' of results by providing it to the next_token parameter.</value>
        [DataMember(Name = "next_token", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "next_token")]
        public string NextToken { get; set; }

        /// <summary>
        /// Number of search query results
        /// </summary>
        /// <value>Number of search query results</value>
        [DataMember(Name = "result_count", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "result_count")]
        public int? ResultCount { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TweetSearchResponseMeta {\n");
            sb.Append("  NewestId: ").Append(NewestId).Append("\n");
            sb.Append("  OldestId: ").Append(OldestId).Append("\n");
            sb.Append("  NextToken: ").Append(NextToken).Append("\n");
            sb.Append("  ResultCount: ").Append(ResultCount).Append("\n");
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