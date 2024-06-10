using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Service;
using System.Collections.Generic;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> GetPublishers()
        {
            var publishers = _publisherService.GetAllPublishers();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost]
        public ActionResult<Publisher> CreatePublisher(Publisher publisher)
        {
            _publisherService.CreatePublisher(publisher);
            return CreatedAtAction(nameof(GetPublisherById), new { id = publisher.PubId }, publisher);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, Publisher publisher)
        {
            if (id != publisher.PubId)
            {
                return BadRequest();
            }
            _publisherService.UpdatePublisher(publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            _publisherService.DeletePublisher(publisher);
            return NoContent();
        }
    }
}
