using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class PublisherDAO
    {
        private readonly ApplicationDbContext _context;

        public PublisherDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetPublisherById(int pubId)
        {
            return _context.Publishers.Find(pubId);
        }

        public void SavePublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _context.Entry(publisher).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeletePublisher(int pubId)
        {
            var publisher = _context.Publishers.Find(pubId);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }
    }
}
