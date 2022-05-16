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
    public class GuestController : ControllerBase
    {
        private IRestaurantLogic _restLogic;
        //private IReviewLogic _revLogic;
        private IMemoryCache _mempryCache;
        public GuestController(IRestaurantLogic _restLogic, /*IReviewLogic _revLogic,*/ IMemoryCache _mempryCache)
        {
            this._restLogic = _restLogic;
            //this._revLogic = _revLogic;
            this._mempryCache = _mempryCache;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Type>>> Get()
        {
            List<Type> _rest = new List<Type>();
            try
            {
                if (!_mempryCache.TryGetValue("restlist", out _rest))
                {
                    _rest = await _restLogic.TDisplayAllRestaurantsAsync();
                    _mempryCache.Set("restlist", _rest, new TimeSpan(0, 1, 0));
                }
            }
            catch (SqlExceptions ex)
            { return BadRequest(ex.Message); }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(_rest);
        }


        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Restaurant> Get(string name)
        {
            if (name == null)
                return BadRequest("Enter a name please");
            var rest = _restLogic.SearchRestaurant("Name", name);
            if (rest.Count <= 0)
                return NotFound("Restaurant not Found");
            return Ok(rest);
        }

    }
}
