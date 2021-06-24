using IHttpClientFactoryDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace IHttpClientFactoryDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public void PostDemo(TodoItem todoItem)
        {
            Console.WriteLine($"调用POST{JsonSerializer.Serialize(todoItem)}");
        }
    }
}
