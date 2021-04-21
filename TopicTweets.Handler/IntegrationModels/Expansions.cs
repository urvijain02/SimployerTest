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
    public class Expansions
    {
        /// <summary>
        /// Gets or Sets Users
        /// </summary>
        [DataMember(Name = "users", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "users")]
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or Sets Tweets
        /// </summary>
        [DataMember(Name = "tweets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tweets")]
        public List<Tweet> Tweets { get; set; }

        /// <summary>
        /// Gets or Sets Places
        /// </summary>
        [DataMember(Name = "places", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "places")]
        public List<Place> Places { get; set; }

        /// <summary>
        /// Gets or Sets Media
        /// </summary>
        [DataMember(Name = "media", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "media")]
        public List<Media> Media { get; set; }

        /// <summary>
        /// Gets or Sets Polls
        /// </summary>
        [DataMember(Name = "polls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "polls")]
        public List<Poll> Polls { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Expansions {\n");
            sb.Append("  Users: ").Append(Users).Append("\n");
            sb.Append("  Tweets: ").Append(Tweets).Append("\n");
            sb.Append("  Places: ").Append(Places).Append("\n");
            sb.Append("  Media: ").Append(Media).Append("\n");
            sb.Append("  Polls: ").Append(Polls).Append("\n");
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