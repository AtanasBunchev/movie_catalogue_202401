using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MC.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }

        [HttpGet("hello")]
        public string Get([FromQuery] int count = 1)
        {
            StringBuilder sb = new();
            for (int i = 0 ; i < count; i++)
            {
                sb.AppendLine("Hello World!");
            }

            return sb.ToString();
        }

        [HttpGet("hello/{name}")]
        public string Get([FromRoute] string name, [FromQuery] int count = 1)
        {
            StringBuilder sb = new();

            for (int i = 0 ; i < count; i++)
            {
                sb.AppendLine($"Hello {name}!");
            }

            return sb.ToString();
        }
    }
}
