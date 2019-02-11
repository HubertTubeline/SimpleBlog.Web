using System;
using System.Collections.Generic;

namespace SimpleBlog.DAL.EF.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public List<Comment> Comments { get; set; }

        public User Author { get; set; }

        public bool IsUpdated { get; set; }

        public DateTimeOffset PostedTime { get; set; }
    }
}
