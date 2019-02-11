using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.Web.Models.Account;

namespace SimpleBlog.Web.Utils
{
    public static class Mapper
    {
        public static User MapUser(AccountViewModel user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}