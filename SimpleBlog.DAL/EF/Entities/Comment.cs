using System;

namespace SimpleBlog.DAL.EF.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public Post Post { get; set; }
        public User Author { get; set; }

        public string Title { get; set; }

        public bool IsUpdated { get; set; }
        public DateTimeOffset PostedTime { get; set; }
    }
}
