using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Annotation inferred from the tweet text.
    /// </summary>
    [DataContract]
    public class ContextAnnotation
    {
        /// <summary>
        /// Gets or Sets Domain
        /// </summary>
        [DataMember(Name = "domain", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "domain")]
        public ContextAnnotationDomainFields Domain { get; set; }

        /// <summary>
        /// Gets or Sets Entity
        /// </summary>
        [DataMember(Name = "entity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "entity")]
        public ContextAnnotationEntityFields Entity { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContextAnnotation {\n");
            sb.Append("  Domain: ").Append(Domain).Append("\n");
            sb.Append("  Entity: ").Append(Entity).Append("\n");
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