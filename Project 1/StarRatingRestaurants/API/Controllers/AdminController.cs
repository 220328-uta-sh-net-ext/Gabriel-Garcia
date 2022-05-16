using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IUserLogic _userLogic;
        private IRestaurantLogic _restLogic;
        private IReviewLogic _revLogic;
        private IMemoryCache _mempryCache;
    }
}
