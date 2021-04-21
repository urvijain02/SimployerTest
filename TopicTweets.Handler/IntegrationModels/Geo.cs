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
    public class Geo
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Bbox
        /// </summary>
        [DataMember(Name = "bbox", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bbox")]
        public List<double?> Bbox { get; set; }

        /// <summary>
        /// Gets or Sets Geometry
        /// </summary>
        [DataMember(Name = "geometry", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "geometry")]
        public Point Geometry { get; set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "properties")]
        public Object Properties { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Geo {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Bbox: ").Append(Bbox).Append("\n");
            sb.Append("  Geometry: ").Append(Geometry).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
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