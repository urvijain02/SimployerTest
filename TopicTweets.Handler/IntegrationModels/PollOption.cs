using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Describes a choice in a Poll object.
    /// </summary>
    [DataContract]
    public class PollOption
    {
        /// <summary>
        /// Position of this choice in the poll.
        /// </summary>
        /// <value>Position of this choice in the poll.</value>
        [DataMember(Name = "position", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "position")]
        public int? Position { get; set; }

        /// <summary>
        /// The text of a poll choice.
        /// </summary>
        /// <value>The text of a poll choice.</value>
        [DataMember(Name = "label", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Number of users who voted for this choice.
        /// </summary>
        /// <value>Number of users who voted for this choice.</value>
        [DataMember(Name = "votes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PollOption {\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Votes: ").Append(Votes).Append("\n");
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