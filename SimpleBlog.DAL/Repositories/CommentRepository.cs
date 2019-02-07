using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBlog.DAL.EF;
using SimpleBlog.DAL.EF.Entities;
using SimpleBlog.DAL.Utils;

namespace SimpleBlog.DAL.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationContext _context;

        public CommentRepository()
        {
            _context = new ApplicationContext();
        }

        public Comment Create(Comment item)
        {
            try
            {
                var result = _context.Comments.Add(item);
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

        public Comment Get(int id)
        {
            try
            {
                var entity = _context.Comments.Find(id);
                return entity;
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public IList<Comment> Get()
        {
            try
            {
                return _context.Comments.ToList();
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Update(Comment item)
        {
            try
            {
                var entity = _context.Comments.Find(item.Id);
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
                _context.Comments.Remove(_context.Comments.Find(id));
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
