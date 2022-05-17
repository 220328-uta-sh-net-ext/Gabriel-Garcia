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
    public class UserController : ControllerBase
    {
        static readonly Reviews rev = new();
        private readonly IRestaurantLogic _restLogic;
        private readonly IUserLogic _userLogic;
        private readonly IMemoryCache _mempryCache;
        private IReviewLogic _revLogic;
        public UserController(IRestaurantLogic _restLogic, IUserLogic _userLogic, IReviewLogic _revLogic, IMemoryCache _mempryCache)
        {
            this._restLogic = _restLogic;
            this._userLogic = _userLogic;
            this._revLogic = _revLogic;
            this._mempryCache = _mempryCache;
        }

        [HttpGet("Display All Restaurants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Restaurant> GetDisplayAllRestaurants()
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

        [HttpGet("Find A Restaurant by Name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize]
        public ActionResult<Restaurant> GetSearchRestaurantsName([FromQuery] string name)
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

        [HttpPost("Add A Review")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult PostReview([FromQuery] string Restaurant_ID, [FromQuery] string UserName, [FromQuery] float Rate_The_Restaurant_1thourgh5, string Leave_A_Review)
        {
            if (Restaurant_ID == null)
            { return BadRequest("Please input a Restaruant ID"); }
            if (UserName == null)
            { return BadRequest("Please input your username"); }
            var r = _restLogic.SearchRestaurant("Id", Restaurant_ID);
            if (r.Count != 1)
                return BadRequest("Restaurant you tried to rate did not exist");
            var u = _userLogic.SearchUserAll("UserName", UserName);
            string getuserid = "";
            if (u.Count != 1)
                return BadRequest("user not found");
            foreach (var i in u)
            {
                getuserid = i.ReviewerId;
            }

            if (Rate_The_Restaurant_1thourgh5 > 5 || Rate_The_Restaurant_1thourgh5 < 0)
                return BadRequest("Please input a valid rate from 1-5");

            var re = _revLogic.DisplayReview("ReviewerId", getuserid);
            if (re.Count > 0)
                _revLogic.DeleteReview("Id", Restaurant_ID, "ReviewerId", getuserid);

            rev.Id = Restaurant_ID;
            rev.ReviewerId = getuserid;
            rev.Rate = Convert.ToInt32(Rate_The_Restaurant_1thourgh5);
            rev.Review = "" + Leave_A_Review;

            _userLogic.AddReviews(rev);
            return Ok($"Your Review was added.");
        }
    }
}
