using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using API.Repository;
using Models;
using BL;
//using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        static readonly Reviews rev = new();
        private readonly IRestaurantLogic _restLogic;
        private readonly IUserLogic _userLogic;
        static readonly User user = new();
        private readonly IMemoryCache _mempryCache;
        private readonly IJWTManagerRepository _repo;
        //private IReviewLogic _revLogic;
        public UserController(IJWTManagerRepository _repo,IRestaurantLogic _restLogic, IUserLogic _userLogic,  IMemoryCache _mempryCache)
        {
            this._restLogic = _restLogic;
            this._userLogic = _userLogic;
            //this._revLogic = _revLogic;
            this._repo = _repo;
            this._mempryCache = _mempryCache;
        }
        /// <summary>
        /// display all restaurant from the database
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "UserMenu")]
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
        /// seach restaurant by name it can be fixable
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// [Authorize(Roles = "UserMenu")]
        [HttpGet("Find A Restaurant by Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Restaurant> SearchRestaurantsName([FromQuery] string name)
        {
            var _rest = new List<Restaurant>();
            try
            {
                _rest = _restLogic.SearchRestaurant("Id", name);
                _mempryCache.Set("restlist", _rest, new TimeSpan(0, 1, 0));
                if (_rest.Count <= 0)
                    return NotFound("Restaurant not Found");
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(_rest);
        }
        /// <summary>
        /// adding a review
        /// 1st check if we got all input
        /// 2nt check if we have the right restaurant
        /// 3th check if we have the right user
        /// 4th check get user id using the username
        /// 5th check if any old review where found if so delete them
        /// 6th add the rate and review
        /// </summary>
        /// <param name="Restaurant_ID"></param>
        /// <param name="UserName"></param>
        /// <param name="Rate_The_Restaurant_1thourgh5"></param>
        /// <param name="Leave_A_Review"></param>
        /// <returns></returns>
        /// [Authorize(Roles = "UserMenu")]
        [HttpPost("Add A Review")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddAReview([FromQuery] string Restaurant_ID, [FromQuery] string UserName, [FromQuery] float Rate_The_Restaurant_1thourgh5, string Leave_A_Review)
        {
            if (Restaurant_ID == null)
            { return BadRequest("Please input a Restaruant ID"); }

            if (UserName == null)
            { return BadRequest("Please input your username"); }

            var restaurant = _restLogic.SearchRestaurant("Id", Restaurant_ID);

            if (restaurant.Count != 1)
                return BadRequest("Restaurant you tried to rate did not exist");

            var user = _userLogic.SearchUserAll("UserName", UserName);

            string getuserid = "";
            if (user.Count != 1)
                return BadRequest("user not found");
            foreach (var u in user)
            {
                getuserid = u.ReviewerId;//get the user id
            }

            if (Rate_The_Restaurant_1thourgh5 > 5 || Rate_The_Restaurant_1thourgh5 < 0)
                return BadRequest("Please input a valid rate from 1-5");

            var re = _userLogic.DisplayReview("ReviewerId", getuserid);
            if (re.Count > 0)
                _userLogic.DeleteReview("Id", Restaurant_ID, "ReviewerId", getuserid);

            rev.Id = Restaurant_ID;
            rev.ReviewerId = getuserid;
            rev.Rate = Convert.ToInt32(Rate_The_Restaurant_1thourgh5);
            rev.Review = "" + Leave_A_Review;

            _userLogic.AddReviews(rev);
            return Ok($"Your Review was added.");
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
            }
            catch (Exception ex)
            {
                return BadRequest("Didn't find the restaurnat: " + ex.Message);
            }
            return Ok(revew);
        }
    }
}
