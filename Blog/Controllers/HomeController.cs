using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")] // Health Check
        public ActionResult Get() 
        {
            return Ok();
        }

    }
}
