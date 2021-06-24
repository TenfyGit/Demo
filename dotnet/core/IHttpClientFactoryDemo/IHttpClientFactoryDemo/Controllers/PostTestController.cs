using IHttpClientFactoryDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IHttpClientFactoryDemo.Controllers
{
    public class PostTestController : Controller
    {
        private readonly HttpClient _httpClient;

        public PostTestController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task PostAsync()
        {
            TodoItem todoItem = new TodoItem() { 
                Id = 123
            };
            var todoItemJson = new StringContent(
                JsonSerializer.Serialize(todoItem),
                Encoding.UTF8,
                "application/json");
            using var httpResponse = await _httpClient.PostAsync("/Home/PostDemo",todoItemJson);
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
