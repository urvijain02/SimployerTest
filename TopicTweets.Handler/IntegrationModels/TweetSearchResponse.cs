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
    public class TweetSearchResponse
    {
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "data")]
        public List<Tweet> Data { get; set; }

        /// <summary>
        /// Gets or Sets Includes
        /// </summary>
        [DataMember(Name = "includes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "includes")]
        public Expansions Includes { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "errors")]
        public List<Problem> Errors { get; set; }

        /// <summary>
        /// Gets or Sets Meta
        /// </summary>
        [DataMember(Name = "meta", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "meta")]
        public TweetSearchResponseMeta Meta { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TweetSearchResponse {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Includes: ").Append(Includes).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  Meta: ").Append(Meta).Append("\n");
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