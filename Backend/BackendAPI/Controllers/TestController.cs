using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BackendAPI.Controllers
{
    [Route("test/api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        // GET api/test
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Successfully pinged Test controller!!" };
        }
    }
}
