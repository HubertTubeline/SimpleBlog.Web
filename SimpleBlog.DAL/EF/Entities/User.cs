using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SimpleBlog.DAL.EF.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }

        public DateTimeOffset RegisterDate { get; set; }
        public DateTimeOffset LatestVisit { get; set; }
    }
}
