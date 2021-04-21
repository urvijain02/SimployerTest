using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopicTweets.Data.Entities
{
    [Table("Tweets")]
    public class Tweet
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(280)]
        public string Text { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}