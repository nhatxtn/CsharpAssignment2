using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookAuthorDAO
    {
        private readonly ApplicationDbContext _context;

        public BookAuthorDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BookAuthor> GetBookAuthors()
        {
            return _context.BookAuthors.Include(ba => ba.Book).Include(ba => ba.Author).ToList();
        }

        public void SaveBookAuthor(BookAuthor bookAuthor)
        {
            _context.BookAuthors.Add(bookAuthor);
            _context.SaveChanges();
        }

        public void DeleteBookAuthor(int bookId, int authorId)
        {
            var bookAuthor = _context.BookAuthors.SingleOrDefault(ba => ba.BookId == bookId && ba.AuthorId == authorId);
            if (bookAuthor != null)
            {
                _context.BookAuthors.Remove(bookAuthor);
                _context.SaveChanges();
            }
        }
    }
}
