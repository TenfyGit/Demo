using LoggingDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogger _logger2;

        public HomeController(ILogger<HomeController> logger,ILoggerFactory factory)
        {
            _logger = logger;
            _logger2 = factory.CreateLogger("HomeController");
        }
        public IActionResult Index()
        {
            return View();
        }
        public void Get()
        {
            string msg = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(msg);
            _logger2.LogInformation($"当前时间:{DateTime.Now}");
        }
        public ActionResult<string> GetString(long id)
        {
            _logger.LogInformation(MyLogEvents.GetItem,"Getting item {Id}",id);
            return id.ToString();
        }
    }
}
