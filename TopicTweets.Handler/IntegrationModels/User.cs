using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// The Twitter User object
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Creation time of this user.
        /// </summary>
        /// <value>Creation time of this user.</value>
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The friendly name of this user, as shown on their profile.
        /// </summary>
        /// <value>The friendly name of this user, as shown on their profile.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name = "username", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Indicates if this user has chosen to protect their Tweets (in other words, if this user's Tweets are private).
        /// </summary>
        /// <value>Indicates if this user has chosen to protect their Tweets (in other words, if this user's Tweets are private).</value>
        [DataMember(Name = "protected", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "protected")]
        public bool? _Protected { get; set; }

        /// <summary>
        /// Indicate if this user is a verified Twitter User.
        /// </summary>
        /// <value>Indicate if this user is a verified Twitter User.</value>
        [DataMember(Name = "verified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "verified")]
        public bool? Verified { get; set; }

        /// <summary>
        /// Gets or Sets Withheld
        /// </summary>
        [DataMember(Name = "withheld", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "withheld")]
        public UserWithheld Withheld { get; set; }

        /// <summary>
        /// The URL to the profile image for this user.
        /// </summary>
        /// <value>The URL to the profile image for this user.</value>
        [DataMember(Name = "profile_image_url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "profile_image_url")]
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// The location specified in the user's profile, if the user provided one. As this is a freeform value, it may not indicate a valid location, but it may be fuzzily evaluated when performing searches with location queries.
        /// </summary>
        /// <value>The location specified in the user's profile, if the user provided one. As this is a freeform value, it may not indicate a valid location, but it may be fuzzily evaluated when performing searches with location queries.</value>
        [DataMember(Name = "location", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// The URL specified in the user's profile.
        /// </summary>
        /// <value>The URL specified in the user's profile.</value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The text of this user's profile description (also known as bio), if the user provided one.
        /// </summary>
        /// <value>The text of this user's profile description (also known as bio), if the user provided one.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Entities
        /// </summary>
        [DataMember(Name = "entities", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "entities")]
        public UserEntities Entities { get; set; }

        /// <summary>
        /// Gets or Sets PinnedTweetId
        /// </summary>
        [DataMember(Name = "pinned_tweet_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "pinned_tweet_id")]
        public string PinnedTweetId { get; set; }

        /// <summary>
        /// Gets or Sets PublicMetrics
        /// </summary>
        [DataMember(Name = "public_metrics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "public_metrics")]
        public UserPublicMetrics PublicMetrics { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  _Protected: ").Append(_Protected).Append("\n");
            sb.Append("  Verified: ").Append(Verified).Append("\n");
            sb.Append("  Withheld: ").Append(Withheld).Append("\n");
            sb.Append("  ProfileImageUrl: ").Append(ProfileImageUrl).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Entities: ").Append(Entities).Append("\n");
            sb.Append("  PinnedTweetId: ").Append(PinnedTweetId).Append("\n");
            sb.Append("  PublicMetrics: ").Append(PublicMetrics).Append("\n");
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