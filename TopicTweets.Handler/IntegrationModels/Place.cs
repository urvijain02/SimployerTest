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
    public class Place
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The human readable name of this place.
        /// </summary>
        /// <value>The human readable name of this place.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets CountryCode
        /// </summary>
        [DataMember(Name = "country_code", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or Sets PlaceType
        /// </summary>
        [DataMember(Name = "place_type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "place_type")]
        public PlaceType PlaceType { get; set; }

        /// <summary>
        /// The full name of this place.
        /// </summary>
        /// <value>The full name of this place.</value>
        [DataMember(Name = "full_name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// The full name of the county in which this place exists.
        /// </summary>
        /// <value>The full name of the county in which this place exists.</value>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets ContainedWithin
        /// </summary>
        [DataMember(Name = "contained_within", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "contained_within")]
        public List<string> ContainedWithin { get; set; }

        /// <summary>
        /// Gets or Sets Geo
        /// </summary>
        [DataMember(Name = "geo", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "geo")]
        public Geo Geo { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Place {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  PlaceType: ").Append(PlaceType).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  ContainedWithin: ").Append(ContainedWithin).Append("\n");
            sb.Append("  Geo: ").Append(Geo).Append("\n");
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