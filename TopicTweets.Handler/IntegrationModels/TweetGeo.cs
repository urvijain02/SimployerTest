using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// The location tagged on the Tweet, if the user provided one.
    /// </summary>
    [DataContract]
    public class TweetGeo
    {
        /// <summary>
        /// Gets or Sets Coordinates
        /// </summary>
        [DataMember(Name = "coordinates", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "coordinates")]
        public Point Coordinates { get; set; }

        /// <summary>
        /// Gets or Sets PlaceId
        /// </summary>
        [DataMember(Name = "place_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "place_id")]
        public string PlaceId { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TweetGeo {\n");
            sb.Append("  Coordinates: ").Append(Coordinates).Append("\n");
            sb.Append("  PlaceId: ").Append(PlaceId).Append("\n");
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