using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleBlog.DAL.EF;
using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.DAL.Utils;

namespace SimpleBlog.DAL.Repositories
{
    public class PostRepository
    {
        private readonly ApplicationContext _context;

        public PostRepository()
        {
            _context = new ApplicationContext();
        }

        public Post Create(Post item)
        {
            try
            {
                var result = _context.Posts.Add(item);
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

        public Post Get(int id)
        {
            try
            {
                var entity = _context.Posts.Find(id);
                return entity;
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public IList<Post> Get(int startPosition = 0, int pageSize = 20)
        {
            try
            {
                return _context.Posts.OrderBy(x => x.PostedTime).Skip(startPosition).Take(pageSize).Include(x => x.Author).Include(x => x.Comments).ToList();
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Update(Post item)
        {
            try
            {
                var entity = _context.Posts.Find(item.Id);
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
                _context.Posts.Remove(_context.Posts.Find(id));
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
