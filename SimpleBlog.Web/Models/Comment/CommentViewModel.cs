using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }
        public string AuthorPhotoUrl { get; set; }
        
        public string Comment { get; set; }
    }
}