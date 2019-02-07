using System.Data.Entity;
using SimpleBlog.DAL.EF.Entities;

namespace SimpleBlog.DAL.EF
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext()
        {
            Database.CreateIfNotExists();
        }
    }
}
