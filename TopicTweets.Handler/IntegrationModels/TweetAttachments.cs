using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Specifies the type of attachments (if any) present in this Tweet.
    /// </summary>
    [DataContract]
    public class TweetAttachments
    {
        /// <summary>
        /// A list of Media Keys for each one of the media attachments (if media are attached).
        /// </summary>
        /// <value>A list of Media Keys for each one of the media attachments (if media are attached).</value>
        [DataMember(Name = "media_keys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "media_keys")]
        public List<string> MediaKeys { get; set; }

        /// <summary>
        /// A list of poll IDs (if polls are attached).
        /// </summary>
        /// <value>A list of poll IDs (if polls are attached).</value>
        [DataMember(Name = "poll_ids", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "poll_ids")]
        public List<string> PollIds { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TweetAttachments {\n");
            sb.Append("  MediaKeys: ").Append(MediaKeys).Append("\n");
            sb.Append("  PollIds: ").Append(PollIds).Append("\n");
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