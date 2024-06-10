using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using X.PagedList;

namespace eBookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _userApiUrl;
        private readonly string _publisherApiUrl;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _userApiUrl = "https://localhost:44325/api/user";
            _publisherApiUrl = "https://localhost:44325/api/publisher";
        }

        public async Task<IActionResult> Index(string sortOrder, string emailSearch, string firstNameSearch, string middleNameSearch, string lastNameSearch, string citySearch, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter_Email"] = emailSearch;
            ViewData["CurrentFilter_FirstName"] = firstNameSearch;
            ViewData["CurrentFilter_MiddleName"] = middleNameSearch;
            ViewData["CurrentFilter_LastName"] = lastNameSearch;
            ViewData["CurrentFilter_City"] = citySearch;

            string query = "";

            // Build filter query based on search strings
            var filters = new List<string>();
            if (!string.IsNullOrEmpty(emailSearch))
            {
                filters.Add($"contains(EmailAddress,'{emailSearch}')");
            }
            if (!string.IsNullOrEmpty(firstNameSearch))
            {
                filters.Add($"contains(FirstName,'{firstNameSearch}')");
            }
            if (!string.IsNullOrEmpty(middleNameSearch))
            {
                filters.Add($"contains(MiddleName,'{middleNameSearch}')");
            }
            if (!string.IsNullOrEmpty(lastNameSearch))
            {
                filters.Add($"contains(LastName,'{lastNameSearch}')");
            }
            if (!string.IsNullOrEmpty(citySearch))
            {
                filters.Add($"contains(Publisher/City,'{citySearch}')");
            }

            if (filters.Any())
            {
                query += "$filter=" + string.Join(" and ", filters);
            }

            // Append sorting criteria if provided
            if (!string.IsNullOrEmpty(sortOrder))
            {
                query += (string.IsNullOrEmpty(query) ? "$orderby=" : "&$orderby=") + sortOrder;
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"{_userApiUrl}?{query}");

            if (response.IsSuccessStatusCode)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<User> users = JsonSerializer.Deserialize<List<User>>(strData, options);

                foreach (var user in users)
                {
                    HttpResponseMessage publisherResponse = await _httpClient.GetAsync($"{_publisherApiUrl}/{user.PubId}");

                    if (publisherResponse.IsSuccessStatusCode)
                    {
                        var publisher = await publisherResponse.Content.ReadFromJsonAsync<Publisher>();
                        user.Publisher = publisher;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Failed to fetch publisher for User with ID {user.UserId}");
                    }
                }

                int pageNumber = (page ?? 1); // If page is null, default to page 1
                int pageSize = 10; // Number of items per page

                return View(users.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(new List<User>().ToPagedList(1, 10)); // Default to an empty list if no data
            }
        }




        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_publisherApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var publishers = await response.Content.ReadFromJsonAsync<List<Publisher>>();
                var publisherList = publishers.Select(p => new SelectListItem
                {
                    Value = p.PubId.ToString(),
                    Text = p.PublisherName
                }).ToList();

                ViewBag.Publishers = new SelectList(publisherList, "Value", "Text");
                return View(new User { RoleId = 1 }); // Set default RoleId to 1
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to fetch publishers.");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_userApiUrl, user);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create user.");
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"API request error: {ex.Message}");
                }
            }

            HttpResponseMessage publisherResponse = await _httpClient.GetAsync(_publisherApiUrl);

            if (publisherResponse.IsSuccessStatusCode)
            {
                var publishers = await publisherResponse.Content.ReadFromJsonAsync<List<Publisher>>();
                var publisherList = publishers.Select(p => new SelectListItem
                {
                    Value = p.PubId.ToString(),
                    Text = p.PublisherName
                }).ToList();

                ViewBag.Publishers = new SelectList(publisherList, "Value", "Text");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to fetch publishers.");
            }

            return View(user);
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_userApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var user = JsonSerializer.Deserialize<User>(strData, options);

                HttpResponseMessage publisherResponse = await _httpClient.GetAsync($"{_publisherApiUrl}/{user.PubId}");

                if (publisherResponse.IsSuccessStatusCode)
                {
                    var publisher = await publisherResponse.Content.ReadFromJsonAsync<Publisher>();
                    user.Publisher = publisher;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Failed to fetch publisher for User with ID {user.UserId}");
                }

                return View(user);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_userApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadFromJsonAsync<User>();
                return View(item);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_userApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_userApiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();

                HttpResponseMessage publisherResponse = await _httpClient.GetAsync(_publisherApiUrl);

                if (publisherResponse.IsSuccessStatusCode)
                {
                    var publishers = await publisherResponse.Content.ReadFromJsonAsync<List<Publisher>>();
                    var publisherList = publishers.Select(p => new SelectListItem
                    {
                        Value = p.PubId.ToString(),
                        Text = p.PublisherName
                    }).ToList();

                    ViewBag.Publishers = new SelectList(publisherList, "Value", "Text");
                }
                else
                {
                    ViewBag.Publishers = new SelectList(new List<string>());
                }

                return View(user);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            if (user.RoleId == 0)
            {
                user.RoleId = 1;
            }

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_userApiUrl}/{id}", user);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Failed to update user. Error: {errorMessage}");

                HttpResponseMessage publisherResponse = await _httpClient.GetAsync(_publisherApiUrl);

                if (publisherResponse.IsSuccessStatusCode)
                {
                    var publishers = await publisherResponse.Content.ReadFromJsonAsync<List<Publisher>>();
                    var publisherList = publishers.Select(p => new SelectListItem
                    {
                        Value = p.PubId.ToString(),
                        Text = p.PublisherName
                    }).ToList();

                    ViewBag.Publishers = new SelectList(publisherList, "Value", "Text");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to fetch publishers.");
                }

                return View(user);
            }
        }
    }
}
