using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TopicTweets.Handler.IntegrationModels
{
    /// <summary>
    /// Indicates withholding details for [withheld content](https://help.twitter.com/en/rules-and-policies/tweet-withheld-by-country).
    /// </summary>
    [DataContract]
    public class UserWithheld
    {
        /// <summary>
        /// Provides a list of countries where this content is not available.
        /// </summary>
        /// <value>Provides a list of countries where this content is not available.</value>
        [DataMember(Name = "country_codes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "country_codes")]
        public List<string> CountryCodes { get; set; }

        /// <summary>
        /// Indicates that the content being withheld is a `user`.
        /// </summary>
        /// <value>Indicates that the content being withheld is a `user`.</value>
        [DataMember(Name = "scope", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserWithheld {\n");
            sb.Append("  CountryCodes: ").Append(CountryCodes).Append("\n");
            sb.Append("  Scope: ").Append(Scope).Append("\n");
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