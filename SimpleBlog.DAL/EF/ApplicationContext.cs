using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.DAL.Identity;

namespace SimpleBlog.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public ApplicationContext()
        {
            //if (Database.Exists()) Database.Delete();

            //Database.Create();
            //InitDb();
            Database.CreateIfNotExists();
            if (Roles.FirstOrDefault(x => x.Name == "User") == null) Roles.Add(new Role {Name = "User"});
        }

        private void InitDb()
        {
            var user = InitUser();
            var posts = InitPosts(user);
            user.Posts = posts;
            var comments = InitComments(user, posts);
            user.Comments = comments;

            var mgr = new UserManager(new UserStore<User>(this));
            mgr.CreateAsync(user, "123456");
            Posts.AddRange(posts);
            Comments.AddRange(comments);
            SaveChanges();
        }

        private List<Comment> InitComments(User user, List<Post> posts)
        {
            var result = new List<Comment>();
            var counter = -1;
            foreach (var post in posts)
            {
                var comments = new List<Comment>();
                for (var i = 0; i < 4; i++)
                    comments.Add(new Comment
                    {
                        Id = ++counter,
                        Post = post,
                        Author = user,
                        Title = "Simple comment on simple post :)",
                        IsUpdated = false,
                        PostedTime = DateTimeOffset.UtcNow
                    });
                post.Comments = comments;
                result.AddRange(comments);
            }

            return result;
        }

        private List<Post> InitPosts(User user)
        {
            var postDescription =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            return new List<Post>
            {
                new Post
                {
                    Id = 0,
                    Author = user,
                    Title = "Simple post in blog #1",
                    Body = postDescription,
                    IsUpdated = false,
                    PostedTime = DateTimeOffset.UtcNow
                },
                new Post
                {
                    Id = 1,
                    Author = user,
                    Title = "Simple post in blog #2",
                    Body = postDescription,
                    IsUpdated = false,
                    PostedTime = DateTimeOffset.UtcNow
                },
                new Post
                {
                    Id = 2,
                    Author = user,
                    Title = "Simple post in blog #3",
                    Body = postDescription,
                    IsUpdated = false,
                    PostedTime = DateTimeOffset.UtcNow
                },
                new Post
                {
                    Id = 3,
                    Author = user,
                    Title = "Simple post in blog #4",
                    Body = postDescription,
                    IsUpdated = false,
                    PostedTime = DateTimeOffset.UtcNow
                },
                new Post
                {
                    Id = 4,
                    Author = user,
                    Title = "Simple post in blog #5",
                    Body = postDescription,
                    IsUpdated = false,
                    PostedTime = DateTimeOffset.UtcNow
                }
            };
        }

        private User InitUser()
        {
            var user = new User
            {
                Email = "admin@gmail.com",
                UserName = "admin",
                FirstName = "Hubert",
                LastName = "Tubeline",
                PhoneNumber = "+380000000",
                RegisterDate = DateTimeOffset.UtcNow,
                LatestVisit = DateTimeOffset.UtcNow
            };

            return user;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasKey(x => x.Id)
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id)
                .HasMany(x => x.Posts)
                .WithRequired(x => x.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasKey(x => x.Id)
                .HasRequired(x => x.Author)
                .WithMany(x => x.Comments)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}