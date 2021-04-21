using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Represent a Poll attached to a Tweet
    /// </summary>
    [DataContract]
    public class Poll
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Options
        /// </summary>
        [DataMember(Name = "options", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "options")]
        public List<PollOption> Options { get; set; }

        /// <summary>
        /// Gets or Sets VotingStatus
        /// </summary>
        [DataMember(Name = "voting_status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "voting_status")]
        public string VotingStatus { get; set; }

        /// <summary>
        /// Gets or Sets EndDatetime
        /// </summary>
        [DataMember(Name = "end_datetime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "end_datetime")]
        public DateTime? EndDatetime { get; set; }

        /// <summary>
        /// Gets or Sets DurationMinutes
        /// </summary>
        [DataMember(Name = "duration_minutes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "duration_minutes")]
        public int? DurationMinutes { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Poll {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Options: ").Append(Options).Append("\n");
            sb.Append("  VotingStatus: ").Append(VotingStatus).Append("\n");
            sb.Append("  EndDatetime: ").Append(EndDatetime).Append("\n");
            sb.Append("  DurationMinutes: ").Append(DurationMinutes).Append("\n");
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