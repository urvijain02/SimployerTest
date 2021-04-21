using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    ///
    /// </summary>
    [DataContract]
    public class FullTextEntities
    {
        /// <summary>
        /// Gets or Sets Urls
        /// </summary>
        [DataMember(Name = "urls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "urls")]
        public List<UrlEntity> Urls { get; set; }

        /// <summary>
        /// Gets or Sets Hashtags
        /// </summary>
        [DataMember(Name = "hashtags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "hashtags")]
        public List<HashtagEntity> Hashtags { get; set; }

        /// <summary>
        /// Gets or Sets Mentions
        /// </summary>
        [DataMember(Name = "mentions", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "mentions")]
        public List<MentionEntity> Mentions { get; set; }

        /// <summary>
        /// Gets or Sets Cashtags
        /// </summary>
        [DataMember(Name = "cashtags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "cashtags")]
        public List<CashtagEntity> Cashtags { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FullTextEntities {\n");
            sb.Append("  Urls: ").Append(Urls).Append("\n");
            sb.Append("  Hashtags: ").Append(Hashtags).Append("\n");
            sb.Append("  Mentions: ").Append(Mentions).Append("\n");
            sb.Append("  Cashtags: ").Append(Cashtags).Append("\n");
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