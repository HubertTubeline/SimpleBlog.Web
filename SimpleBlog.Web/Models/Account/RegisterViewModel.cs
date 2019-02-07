namespace SimpleBlog.Web.Models.Account
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] Photo { get; set; }
    }
}