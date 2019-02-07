using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Models.Comment
{
    public class CreateCommentViewModel
    {
        public int AuthorId { get; set; }
        public int PostId { get; set; }

        public string Title { get; set; }
    }
}