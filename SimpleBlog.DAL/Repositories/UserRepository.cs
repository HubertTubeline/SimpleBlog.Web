using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBlog.DAL.EF;
using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.DAL.Utils;

namespace SimpleBlog.DAL.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository()
        {
            _context = new ApplicationContext();
        }

        public User Create(User item)
        {
            try
            {
                var result = _context.Users.Add(item);
                _context.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public User Get(int id)
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

        public bool Update(User item)
        {
            try
            {
                var entity = _context.Users.Find(item.Id);
                if (entity == null) return false;

                entity.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _context.Users.Remove(_context.Users.Find(id));
                _context.SaveChanges();
                return true;
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
