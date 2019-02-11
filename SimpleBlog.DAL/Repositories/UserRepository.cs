using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleBlog.DAL.EF;
using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.DAL.Identity;
using SimpleBlog.DAL.Utils;

namespace SimpleBlog.DAL.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;
        private readonly UserManager _manager;

        public UserRepository()
        {
            _context = new ApplicationContext();
            _manager = new UserManager(new UserStore<User>(_context));
        }

        public async Task<ClaimsIdentity> AuthAsync(string email, string password)
        {
            ClaimsIdentity claim = null;
            User user = await _manager.FindAsync(email, password);
            if (user != null)
                claim = await _manager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task<IdentityResult> CreateUserAsync(User item, string password)
        {
            try
            {
                return await _manager.CreateAsync(item, password);
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return new IdentityResult(e.Message);
            }
        }

        public User Get(string id)
        {
            try
            {
                var entity = _context.Users.Find(id);
                return entity;
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public IList<User> Get()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public OperationDetails Update(User item)
        {
            try
            {
                var entity = _context.Users.Find(item.Id);
                if (entity == null) return new OperationDetails(false, "User not found");
                entity.Update(item);
                _context.SaveChanges();
                return new OperationDetails(true, "User was successfully updated");
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return new OperationDetails(false, e.Message);
            }
        }

        public OperationDetails Delete(string id)
        {
            try
            {
                _context.Users.Remove(_context.Users.Find(id));
                _context.SaveChanges();
                return new OperationDetails(true, "User was successfully deleted");
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return new OperationDetails(false, e.Message);
            }
        }

        public bool FindEmail(string email)
        {
            try
            {
                return _context.Users.FirstOrDefault(x => x.Email == email) != null;
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
