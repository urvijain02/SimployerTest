using System.ComponentModel.DataAnnotations;

namespace TopicTweets.Handler.Models
{
    public class TopicRequest
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}