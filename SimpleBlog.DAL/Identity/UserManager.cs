using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SimpleBlog.DAL.EF;
using SimpleBlog.DAL.EF.Entities;

namespace SimpleBlog.DAL.Identity
{
    public class UserManager : UserManager<User>
    {
        private readonly IUserStore<User> _store;
        private readonly UserManager<User> _manager;
        public UserManager(IUserStore<User> store)
            : base(store)
        {
            _store = store;
            _manager = new UserManager<User>(_store);
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options,
            IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            UserManager manager = new UserManager(new UserStore<User>(db));
            return manager;
        }


    }
}
