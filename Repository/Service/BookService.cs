using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        { 
            _bookRepository = (Repository<Book>)(bookRepository ?? throw new ArgumentNullException(nameof(bookRepository)));

        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public void CreateBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.Delete(book);
        }
    }
}
