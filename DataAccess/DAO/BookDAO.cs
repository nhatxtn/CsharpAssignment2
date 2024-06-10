using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BookDAO
    {
        private readonly ApplicationDbContext _context;

        public BookDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.Include(b => b.Publisher).ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.Include(b => b.Publisher).SingleOrDefault(b => b.BookId == bookId);
        }

        public void SaveBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
