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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 

    public class AdminController : ControllerBase
    {
        static readonly Location loc = new();
        static readonly Restaurant rest = new();
        static readonly Reviews rev = new();
        static readonly User user = new();

        private readonly IRestaurantLogic _restLogic;
        private readonly IUserLogic _userLogic;
        //private IReviewLogic _revLogic;

        private readonly IMemoryCache _mempryCache;
        private readonly IJWTManagerRepository _repo;

        public AdminController(IJWTManagerRepository _repo, IRestaurantLogic _restLogic, IUserLogic _userLogic, IMemoryCache _mempryCache)
        {
            this._repo = _repo;
            this._restLogic = _restLogic;
            this._userLogic = _userLogic;
            //this._revLogic = _revLogic;
            this._mempryCache = _mempryCache;
        }
        /// <summary>
        /// in class contoller login 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /*[HttpPost]
        [Route("Admin")]
        public IActionResult AdminLogin([FromQuery] string UserName, string Password)
        {
            user.UserName = UserName;
            user.Password = Password;
            var token = _repo.Authenticate(user);
            if (token == null)
            { return Unauthorized();
                Log.Information("Admin fail to login");
            }
            AuthorizationPolicy.ReferenceEquals(user.UserName, UserName);

            Log.Information("Admin login");
            return Ok(token);
        }*/
        /// <summary>
        /// display all user will ignoring admin, and passwords
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "AdminMenu")]
        [HttpGet("Display All User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<User> GetDisplayAllUserName()
        {
            var _user = new List<User>();
            try
            {
                _user = _userLogic.DisplayAllUser();
                _mempryCache.Set("restlist", _user, new TimeSpan(0, 1, 0));
                Log.Information("try print user");
            }
            catch (Exception ex)
            { return BadRequest(ex.Message);
                Log.Information("fail user print");
            }

            Log.Information("print user");
            return Ok(_user);
        }
        /// <summary>
        /// get a single user using there username
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        //[Authorize(Roles = "AdminMenu")]
        [HttpGet("Search User By UserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<User> GetSearchUserName([FromQuery] string name)
        {
            var _user = new List<User>();
            try
            {
                _user = _userLogic.SearchUser("UserName", name);
                _mempryCache.Set("restlist", _user, new TimeSpan(0, 1, 0));

            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }


            Log.Information("print user");
            return Ok(_user);
        }
        /// <summary>
        /// get and display all the restaurant in the database
        /// </summary>
        /// <returns></returns>

        //[Authorize(Roles = "AdminMenu")]
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


            Log.Information("print restaurants");
            return Ok(_rest);
        }
        /// <summary>
        /// display all restaurant with the same name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[Authorize(Roles = "AdminMenu")]
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


            Log.Information("print restaurants");
            return Ok(_rest);
        }
        /// <summary>
        /// adding a restaurant 
        /// we set the id inside
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <param name="zip"></param>
        /// <returns></returns>

        //[Authorize(Roles = "AdminMenu")]
        [HttpPost("Add A Restaurant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddARestaurant([FromQuery]string name, [FromQuery] string country, [FromQuery] string state, [FromQuery] string city, [FromQuery] string zip)
        {
            DateTime localDate = DateTime.Now;
            rest.Name = name;
            rest.Id = localDate.Year.ToString() + localDate.Month.ToString() + localDate.Day.ToString() + localDate.Hour.ToString() + localDate.Minute.ToString() + numberOfRestaurant();
            loc.Id = rest.Id;
            loc.Country = country;
            loc.State = state;
            loc.City = city;
            loc.Zipcode = zip;
            
            _restLogic.AddRestaurant(rest,loc);

            Log.Information("add restaurants");
            return Ok($"Restaurant {rest.Name} was added.");
        }
        private int numberOfRestaurant()
        {
            int iCount = 0;
            List<Restaurant>? restl = _restLogic.DisplayAllRestaurants();
            foreach (Restaurant r in restl)
            {
                iCount++;
            }
            return iCount+1;
        }

        /// <summary>
        /// delete a restaurant 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = "AdminMenu")]
        [HttpDelete("Delete A Restaurant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest("Cannot modify without name");
            _restLogic.DeleteRestaurant(id);
            var rest = _restLogic.SearchRestaurant("Id", id);
            if (rest.Count > 0)
                return BadRequest("Was Unable to Delete");

            Log.Information("delete restaurants");
            return Ok($"Restaurant was deleted ");
        }
        /// <summary>
        /// add a review
        /// </summary>
        /// <param name="Restaurant_ID"></param>
        /// <param name="UserName"></param>
        /// <param name="Rate_The_Restaurant_1thourgh5"></param>
        /// <param name="Leave_A_Review"></param>
        /// <returns></returns>
        //[Authorize(Roles = "AdminMenu")]
        [HttpPost("Add A Review")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddReview([FromQuery] string Restaurant_ID, [FromQuery] string UserName,[FromQuery] float Rate_The_Restaurant_1thourgh5, string Leave_A_Review)
        {
            if (Restaurant_ID == null)
            { return BadRequest("Please input a Restaruant ID"); }
            if(UserName == null)
            { return BadRequest("Please input your username"); }
            var r = _restLogic.SearchRestaurant("Id", Restaurant_ID);
            if(r.Count != 1)
                return BadRequest("Restaurant you tried to rate did not exist");
            var u = _userLogic.SearchUserAll("UserName", UserName);
            string getuserid = "";
            if(u.Count != 1)
                return BadRequest("user not found");
            foreach(var i in u)
            {
                getuserid = i.ReviewerId;
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
            Log.Information("add review");
            return Ok($"Your Review was added.");
        }
    }
}
