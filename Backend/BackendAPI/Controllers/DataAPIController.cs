using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace BackendAPI.Controllers
{
    [Route("dataapi/api/[controller]")]
    [ApiController]
    public class DataAPIController : Controller
    {
        // GET api/test2
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Successfully pinged Test2 controller from SimpleApp Project AND Allow Any Origin 7!!");
            int nStrings = 10;
            string[] outStrings = new string[nStrings];
            for (int i = 0; i < nStrings; i++)
            {
                outStrings[i] = "Successfully built string #" + (i + 1);
            }
            return outStrings;
        }

        // GET api/test2/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<string> Get(int id)
        {
            return "You typed in value: " + id + " to the Test 2 controller";
        }
    }
}
