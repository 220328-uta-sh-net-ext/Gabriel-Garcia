using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractAPI : ControllerBase
    {
        //Actions Methods
        [HttpGet]
        public string Get()
        {
            return "Meow World";
        }
    }
}
