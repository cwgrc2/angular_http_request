using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace BackendAPI.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        // GET api/test
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Successfully pinged Test controller from SimpleApp Project AND Allow Any Origin 7!!");
            return new string[] { "Successfully pinged Test controller from SimpleApp Project AND Allow Any Origin 7!!" };
        }
    }
}
