using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Represent the portion of text recognized as a URL, and its start and end position within the text.
    /// </summary>
    [DataContract]
    public class UrlEntity : EntityIndices
    {
        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets ExpandedUrl
        /// </summary>
        [DataMember(Name = "expanded_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "expanded_url")]
        public string ExpandedUrl { get; set; }

        /// <summary>
        /// The URL as displayed in the Twitter client.
        /// </summary>
        /// <value>The URL as displayed in the Twitter client.</value>
        [DataMember(Name = "display_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "display_url")]
        public string DisplayUrl { get; set; }

        /// <summary>
        /// Fully resolved url
        /// </summary>
        /// <value>Fully resolved url</value>
        [DataMember(Name = "unwound_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "unwound_url")]
        public string UnwoundUrl { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        public int? Status { get; set; }

        /// <summary>
        /// Title of the page the URL points to.
        /// </summary>
        /// <value>Title of the page the URL points to.</value>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Description of the URL landing page.
        /// </summary>
        /// <value>Description of the URL landing page.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Images
        /// </summary>
        [DataMember(Name = "images", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "images")]
        public List<URLImage> Images { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UrlEntity {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  ExpandedUrl: ").Append(ExpandedUrl).Append("\n");
            sb.Append("  DisplayUrl: ").Append(DisplayUrl).Append("\n");
            sb.Append("  UnwoundUrl: ").Append(UnwoundUrl).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Images: ").Append(Images).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}