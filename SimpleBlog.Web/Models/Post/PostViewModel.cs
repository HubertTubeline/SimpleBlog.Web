namespace SimpleBlog.Web.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }

        public byte[] Image { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhotoUrl { get; set; }
    }
}