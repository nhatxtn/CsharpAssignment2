using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eBookStore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _authorApiUrl;
        private readonly string _publisherApiUrl;

        public AuthorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _authorApiUrl = "https://localhost:44325/api/author";
            _publisherApiUrl = "https://localhost:44325/api/publisher";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_authorApiUrl);

            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Author> authors = JsonSerializer.Deserialize<List<Author>>(strData, options);
                return View(authors);
            }
            else
            { 
                return View(new List<Author>());
            }
        }
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_publisherApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var publishers = await response.Content.ReadFromJsonAsync<List<Publisher>>();
                var cities = publishers.Select(p => p.City).Distinct().ToList();

                ViewBag.Cities = new SelectList(cities);
                return View();
            }
            else
            { 
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    City = model.City,
                    EmailAddress = model.EmailAddress
                };

                var response = await _httpClient.PostAsJsonAsync(_authorApiUrl, author);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                { 
                    ModelState.AddModelError(string.Empty, "Failed to create author.");
                }
            }
             
            var publisherResponse = await _httpClient.GetAsync(_publisherApiUrl);
            if (publisherResponse.IsSuccessStatusCode)
            {
                var publishers = await publisherResponse.Content.ReadFromJsonAsync<List<Publisher>>();
                var cities = publishers.Select(p => p.City).Distinct().ToList();
                ViewBag.Cities = new SelectList(cities);
            }

            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{_authorApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var author = await response.Content.ReadFromJsonAsync<Author>();
                return View(author);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            { 
                return BadRequest();
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_authorApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var author = await response.Content.ReadFromJsonAsync<Author>();
                 
                HttpResponseMessage publisherResponse = await _httpClient.GetAsync(_publisherApiUrl);

                if (publisherResponse.IsSuccessStatusCode)
                {
                    var publishers = await publisherResponse.Content.ReadFromJsonAsync<List<Publisher>>();
                    var cities = publishers.Select(p => p.City).Distinct().ToList();

                    ViewBag.Cities = new SelectList(cities);
                }
                else
                { 
                    ViewBag.Cities = new SelectList(new List<string>());
                }

                return View(author);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            { 
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            var response = await _httpClient.PutAsJsonAsync($"{_authorApiUrl}/{id}", author);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Handle error response
                ModelState.AddModelError(string.Empty, "Failed to update author.");
                return View(author);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{_authorApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var author = await response.Content.ReadFromJsonAsync<Author>();
                return View(author);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            { 
                return BadRequest();
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_authorApiUrl}/{id}");

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
                return BadRequest();
            }
        }
    }
} 
