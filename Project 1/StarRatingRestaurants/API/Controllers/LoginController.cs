using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Repository;
using Models;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        //static readonly User user = new();
        //private IUserLogic _userLogic;
        //private IRestaurantLogic _restLogic;
        //private IReviewLogic _revLogic;
        //private IMemoryCache _mempryCache;
        private readonly IJWTManagerRepository _repo;
        public LoginController(IJWTManagerRepository _repo)
        {
            this._repo = _repo;
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("Admin")]
        public IActionResult AdminLogin(User user)
        {
            var token = _repo.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        /*//[AllowAnonymous]
        [HttpPost]
        [Route("User")]
        
        //[AllowAnonymous]
        [HttpPost]
        [Route("Admin")]
        public IActionResult AdminLogin([FromQuery] string UserName, string Password)
        {
            user.UserName = UserName;
            user.Password = Password;
            var token = _repo.Authenticate(user);
            if(token == null)
                return Unauthorized();
            return Ok(token);
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("User")]
        public IActionResult UserLogin([FromQuery] string UserName, string Password)
        {
            if (UserName == "Admin")
            { return BadRequest("Admin?"); }
            user.UserName = UserName;
            user.Password = Password;
            var token = _repo.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        /*public IActionResult Authenticate(User user)
        {
            var token = _repo.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }*/
    }
}
