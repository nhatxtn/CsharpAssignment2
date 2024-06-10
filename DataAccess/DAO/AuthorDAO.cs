using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AuthorDAO
    {
        private readonly ApplicationDbContext _context;

        public AuthorDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return _context.Authors.Find(authorId);
        }

        public void SaveAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _context.Authors.Find(authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
