using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleBlog.DAL.EF.Entities;

namespace SimpleBlog.DAL.Identity
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(RoleStore<Role> store)
            : base(store)
        { }
    }
}
