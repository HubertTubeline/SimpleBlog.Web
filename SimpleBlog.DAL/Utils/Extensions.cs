using SimpleBlog.DAL.EF.Entities;

namespace SimpleBlog.DAL.Utils
{
    static class Extensions
    {
        public static void Update(this User entity, User user)
        {
            if(!string.IsNullOrWhiteSpace(user.Email))
                entity.Email = user.Email;

            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.PhoneNumber = user.PhoneNumber;

            entity.LatestVisit = user.LatestVisit;
        }

        public static void Update(this Post entity, Post post)
        {
            if(!string.IsNullOrWhiteSpace(post.Title))
                entity.Title = post.Title;

            if(!string.IsNullOrWhiteSpace(post.Body))
                entity.Body = post.Body;

            entity.IsUpdated = true;
        }

        public static void Update(this Comment entity, Comment comment)
        {
            entity.Title = comment.Title;
            entity.IsUpdated = true;
        }
    }
}
