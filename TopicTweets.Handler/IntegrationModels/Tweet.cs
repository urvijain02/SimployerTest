using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    ///
    /// </summary>
    [DataContract]
    public class Tweet
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Creation time of the Tweet.
        /// </summary>
        /// <value>Creation time of the Tweet.</value>
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The content of the Tweet.
        /// </summary>
        /// <value>The content of the Tweet.</value>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or Sets AuthorId
        /// </summary>
        [DataMember(Name = "author_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "author_id")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Gets or Sets InReplyToUserId
        /// </summary>
        [DataMember(Name = "in_reply_to_user_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }

        /// <summary>
        /// Gets or Sets ConversationId
        /// </summary>
        [DataMember(Name = "conversation_id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "conversation_id")]
        public string ConversationId { get; set; }

        /// <summary>
        /// Gets or Sets ReplySettings
        /// </summary>
        [DataMember(Name = "reply_settings", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "reply_settings")]
        public ReplySettings ReplySettings { get; set; }

        /// <summary>
        /// A list of Tweets this Tweet refers to. For example, if the parent Tweet is a Retweet, a Quoted Tweet or a Reply, it will include the related Tweet referenced to by its parent.
        /// </summary>
        /// <value>A list of Tweets this Tweet refers to. For example, if the parent Tweet is a Retweet, a Quoted Tweet or a Reply, it will include the related Tweet referenced to by its parent.</value>
        [DataMember(Name = "referenced_tweets", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "referenced_tweets")]
        public List<TweetReferencedTweets> ReferencedTweets { get; set; }

        /// <summary>
        /// Gets or Sets Attachments
        /// </summary>
        [DataMember(Name = "attachments", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "attachments")]
        public TweetAttachments Attachments { get; set; }

        /// <summary>
        /// Gets or Sets ContextAnnotations
        /// </summary>
        [DataMember(Name = "context_annotations", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "context_annotations")]
        public List<ContextAnnotation> ContextAnnotations { get; set; }

        /// <summary>
        /// Gets or Sets Withheld
        /// </summary>
        [DataMember(Name = "withheld", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "withheld")]
        public TweetWithheld Withheld { get; set; }

        /// <summary>
        /// Gets or Sets Geo
        /// </summary>
        [DataMember(Name = "geo", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "geo")]
        public TweetGeo Geo { get; set; }

        /// <summary>
        /// Gets or Sets Entities
        /// </summary>
        [DataMember(Name = "entities", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "entities")]
        public FullTextEntities Entities { get; set; }

        /// <summary>
        /// Gets or Sets PublicMetrics
        /// </summary>
        [DataMember(Name = "public_metrics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "public_metrics")]
        public TweetPublicMetrics PublicMetrics { get; set; }

        /// <summary>
        /// Indicates if this Tweet contains URLs marked as sensitive, for example content suitable for mature audiences.
        /// </summary>
        /// <value>Indicates if this Tweet contains URLs marked as sensitive, for example content suitable for mature audiences.</value>
        [DataMember(Name = "possibly_sensitive", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "possibly_sensitive")]
        public bool? PossiblySensitive { get; set; }

        /// <summary>
        /// Language of the Tweet, if detected by Twitter. Returned as a BCP47 language tag.
        /// </summary>
        /// <value>Language of the Tweet, if detected by Twitter. Returned as a BCP47 language tag.</value>
        [DataMember(Name = "lang", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        /// <summary>
        /// The name of the app the user Tweeted from.
        /// </summary>
        /// <value>The name of the app the user Tweeted from.</value>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or Sets NonPublicMetrics
        /// </summary>
        [DataMember(Name = "non_public_metrics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "non_public_metrics")]
        public TweetNonPublicMetrics NonPublicMetrics { get; set; }

        /// <summary>
        /// Gets or Sets PromotedMetrics
        /// </summary>
        [DataMember(Name = "promoted_metrics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "promoted_metrics")]
        public TweetPromotedMetrics PromotedMetrics { get; set; }

        /// <summary>
        /// Gets or Sets OrganicMetrics
        /// </summary>
        [DataMember(Name = "organic_metrics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "organic_metrics")]
        public TweetOrganicMetrics OrganicMetrics { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Tweet {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  AuthorId: ").Append(AuthorId).Append("\n");
            sb.Append("  InReplyToUserId: ").Append(InReplyToUserId).Append("\n");
            sb.Append("  ConversationId: ").Append(ConversationId).Append("\n");
            sb.Append("  ReplySettings: ").Append(ReplySettings).Append("\n");
            sb.Append("  ReferencedTweets: ").Append(ReferencedTweets).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("  ContextAnnotations: ").Append(ContextAnnotations).Append("\n");
            sb.Append("  Withheld: ").Append(Withheld).Append("\n");
            sb.Append("  Geo: ").Append(Geo).Append("\n");
            sb.Append("  Entities: ").Append(Entities).Append("\n");
            sb.Append("  PublicMetrics: ").Append(PublicMetrics).Append("\n");
            sb.Append("  PossiblySensitive: ").Append(PossiblySensitive).Append("\n");
            sb.Append("  Lang: ").Append(Lang).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  NonPublicMetrics: ").Append(NonPublicMetrics).Append("\n");
            sb.Append("  PromotedMetrics: ").Append(PromotedMetrics).Append("\n");
            sb.Append("  OrganicMetrics: ").Append(OrganicMetrics).Append("\n");
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