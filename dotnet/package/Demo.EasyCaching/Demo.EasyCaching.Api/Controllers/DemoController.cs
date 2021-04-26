using Demo.EasyCaching.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.EasyCaching.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _service;

        public DemoController(IDemoService service)
        {
            this._service = service;
        }

        [HttpGet]
        public string Get(int type = 1)
        {
            if (type == 1)
            {
                return _service.GetCurrentUtcTime();
            }
            else if (type == 2)
            {
                _service.DeleteSomething(1);
                return "ok";
            }
            else if (type == 3)
            {
                return _service.PutSomething("123");
            }
            else
            {
                return "other";
            }
        }
    }
}
