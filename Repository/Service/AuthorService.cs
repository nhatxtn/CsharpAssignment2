using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class AuthorService
    {
        private readonly Repository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = (Repository<Author>)(authorRepository ?? throw new ArgumentNullException(nameof(authorRepository)));
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll().ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void CreateAuthor(Author author)
        {
            _authorRepository.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            _authorRepository.Delete(author);
        }
    }
}
