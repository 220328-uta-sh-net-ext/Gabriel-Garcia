using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        static readonly User user = new();
        private readonly IRestaurantLogic _restLogic;
        private readonly IUserLogic _userLogic;
        private readonly IMemoryCache _mempryCache;
        //private IReviewLogic _revLogic;
        public GuestController(IRestaurantLogic _restLogic, IUserLogic _userLogic, IMemoryCache _mempryCache)
        {
            this._restLogic = _restLogic;
            this._userLogic = _userLogic;
            //this._revLogic = _revLogic;
            this._mempryCache = _mempryCache;
        }
        /// <summary>
        /// display all restaurants
        /// </summary>
        /// <returns></returns>

        [HttpGet("Display All Restaurants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Restaurant> DisplayAllRestaurants()
        {
            var _rest = new List<Restaurant>();
            try
            {
                _rest = _restLogic.DisplayAllRestaurants();
                _mempryCache.Set("restlist", _rest, new TimeSpan(0, 1, 0));

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(_rest);
        }
        /// <summary>
        /// find a restrant using name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Find A Restaurant by Name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public ActionResult<Restaurant> SearchRestaurantsName([FromQuery] string name)
        {
            var _rest = new List<Restaurant>();
            try
            {
                _rest = _restLogic.SearchRestaurant("Name", name);
                _mempryCache.Set("restlist", _rest, new TimeSpan(0, 1, 0));
                if (_rest.Count <= 0)
                    return NotFound("Restaurant not Found");
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(_rest);
        }
        /// <summary>
        /// add a user if username not found
        /// </summary>
        /// <param name="First_Name"></param>
        /// <param name="Last_Name"></param>
        /// <param name="Email"></param>
        /// <param name="User_Name"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost("Add A User")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddUser([FromQuery] string First_Name, string Last_Name, string Email, string User_Name, string Password)
        {
            if (User_Name == null || User_Name == "")
            {
                return BadRequest("Please input a username");
            }
            if (Email == null || Email == "")
            {
                return BadRequest("Please input a username");
            }
            if (Password == null || Password == "")
            { return BadRequest("Please input a password"); }

            var u = _userLogic.SearchUserAll("UserName", User_Name);
            if (u.Count > 0)
            { return BadRequest("Sorry! But the UserName you inputed is in use"); }
            if (u.Count == 0)
            {
                DateTime localDate = DateTime.Now;
                user.ReviewerId = localDate.Year.ToString() + localDate.Month.ToString() + localDate.Day.ToString() + localDate.Hour.ToString() + localDate.Minute.ToString() + User_Name.Last();

                user.FirstName = "" + First_Name;
                user.LastName = "" + Last_Name;
                user.Email = Email;
                user.UserName = User_Name;
                user.Password = Password;

                _userLogic.AddUser(user);
                return Ok($"Your Review was added.");

            }
            return BadRequest("Something gone wrong!");
        }
        /// <summary>
        /// get a reviews
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("See Review")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SeeReview([FromQuery] string id)
        {
            string revew = "";
            try
            {
                revew = _restLogic.GetRestaurant(id);
            }catch (Exception ex)
            {
                return BadRequest("Didn't find the restaurnat: " +ex.Message);
            }
            return Ok(revew);
        }

    }
}
