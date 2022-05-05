using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PracAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractApi : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Meow World";
        }
    }
}
