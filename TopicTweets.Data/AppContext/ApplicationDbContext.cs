using Microsoft.EntityFrameworkCore;
using TopicTweets.Data.Entities;

namespace TopicTweets.Data.AppContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        
        public DbSet<Tweet> Tweets { get; set; }

        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}