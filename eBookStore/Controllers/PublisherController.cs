using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace eBookStore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _publisherApiUrl;

        public PublisherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _publisherApiUrl = "https://localhost:44325/api/publisher";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_publisherApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Publisher> listProducts = JsonSerializer.Deserialize<List<Publisher>>(strData, options);
            return View(listProducts);

        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_publisherApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var publisher = await response.Content.ReadFromJsonAsync<Publisher>();
                return View(publisher);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle the error response
                return BadRequest();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_publisherApiUrl, publisher);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle the error response
                ModelState.AddModelError(string.Empty, "Failed to create publisher.");
                return View(publisher);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_publisherApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var publisher = await response.Content.ReadFromJsonAsync<Publisher>();
                return View(publisher);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle the error response
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Publisher publisher)
        {
            if (id != publisher.PubId)
            {
                return BadRequest();
            }

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_publisherApiUrl}/{id}", publisher);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle the error response
                ModelState.AddModelError(string.Empty, "Failed to update publisher.");
                return View(publisher);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_publisherApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                // Handle the error response
                return BadRequest();
            }
        }
    }
}
