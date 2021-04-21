using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Expanded details for the URL specified in the user&#x27;s profile, with start and end indices.
    /// </summary>
    [DataContract]
    public class UserEntitiesUrl
    {
        /// <summary>
        /// Gets or Sets Urls
        /// </summary>
        [DataMember(Name = "urls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "urls")]
        public List<UrlEntity> Urls { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserEntitiesUrl {\n");
            sb.Append("  Urls: ").Append(Urls).Append("\n");
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