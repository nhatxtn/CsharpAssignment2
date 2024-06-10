using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public class PublisherService
    {
        private readonly Repository<Publisher> _publisherRepository;

        public PublisherService(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = (Repository<Publisher>)(publisherRepository ?? throw new ArgumentNullException(nameof(publisherRepository)));
        }

        public List<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll().ToList();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.GetById(id);
        }

        public void CreatePublisher(Publisher publisher)
        {
            _publisherRepository.Add(publisher);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _publisherRepository.Update(publisher);
        }

        public void DeletePublisher(Publisher publisher)
        {
            _publisherRepository.Delete(publisher);
        }
    }
}
