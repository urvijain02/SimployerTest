using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Represent a boundary range (start and end index) for a recognized entity (for example a hashtag or a mention). &#x60;start&#x60; must be smaller than &#x60;end&#x60;.
    /// </summary>
    [DataContract]
    public class EntityIndices
    {
        /// <summary>
        /// Index (zero-based) at which position this entity starts.
        /// </summary>
        /// <value>Index (zero-based) at which position this entity starts.</value>
        [DataMember(Name = "start", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "start")]
        public int? Start { get; set; }

        /// <summary>
        /// Index (zero-based) at which position this entity ends.
        /// </summary>
        /// <value>Index (zero-based) at which position this entity ends.</value>
        [DataMember(Name = "end", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "end")]
        public int? End { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntityIndices {\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  End: ").Append(End).Append("\n");
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