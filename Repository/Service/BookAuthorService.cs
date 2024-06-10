using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class BookAuthorService
    {
        private readonly IRepository<BookAuthor> _bookAuthorRepository;

        public BookAuthorService(IRepository<BookAuthor> bookAuthorRepository)
        { 
            _bookAuthorRepository = (Repository<BookAuthor>)(bookAuthorRepository ?? throw new ArgumentNullException(nameof(bookAuthorRepository)));

        }

        public List<BookAuthor> GetAllBookAuthors()
        {
            return _bookAuthorRepository.GetAll().ToList();
        }

        public BookAuthor GetBookAuthorById(int bookId, int authorId)
        {
            return _bookAuthorRepository.GetById(bookId, authorId);
        }

        public void CreateBookAuthor(BookAuthor bookAuthor)
        {
            _bookAuthorRepository.Add(bookAuthor);
        }

        public void UpdateBookAuthor(BookAuthor bookAuthor)
        {
            _bookAuthorRepository.Update(bookAuthor);
        }

        public void DeleteBookAuthor(BookAuthor bookAuthor)
        {
            _bookAuthorRepository.Delete(bookAuthor);
        }
    }
}
