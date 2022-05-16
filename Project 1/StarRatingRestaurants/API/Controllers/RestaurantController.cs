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
    public class RestaurantController : ControllerBase
    {
        private IRestaurantLogic _restLogic;
        private IMemoryCache _mempryCache;
        public RestaurantController(IRestaurantLogic _restLogic, IMemoryCache _mempryCache)
        {
            this._restLogic = _restLogic;
            this._mempryCache = _mempryCache;
        }

        //action methods: do things (get,put,post, delete, patch...)
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult< List<Restaurant>>> Get()
        {
            List<Restaurant> _rest = new List<Restaurant>();
            try
            {
                if(!_mempryCache.TryGetValue("restlist",out _rest))
                {
                    _rest = await _restLogic.DisplayAllRestaurantsAsync();
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
            var rest = _restLogic.SearchRestaurant("Name",name);
            if (rest.Count <= 0)
                return NotFound("Restaurant not Found");
            return Ok(rest);
        }


        //
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Restaurant rest)
        {
            if(rest == null)
            { return BadRequest("Invalid Restaurant"); }
            _restLogic.AddRestaurant(rest);
            return CreatedAtAction("Get",rest);
        }


        [HttpPut]
        public ActionResult Put([FromQuery] Restaurant rest, [FromBody] string name)
        {/*
            if (name == null)
                return BadRequest("Cannot modify without name");
            var restaur = _restaurants.Find(x => x.Name.Contains(name));
            
            if (restaur == null)
            { return NotFound("Restaurant Not found "); }
            restaur.Name = rest.Name;
            restaur.Id = rest.Id;
            restaur.Country = rest.Country;
            restaur.State = rest.State;
            restaur.City = rest.City;
            restaur.Zipcode = rest.Zipcode;*/
            return Created("Get", rest);
        }


        [HttpDelete]
        public ActionResult Delete( string name)
        {/*
            if (name == null)
                return BadRequest("Cannot modify without name");
            var restaur = _restaurants.Find(x => x.Name.Contains(name));

            if (restaur == null)
            { return NotFound("Restaurant Not found "); }
            _restaurants.Remove(restaur);*/

            return Ok($"Restaurant {name} deleted ");
        }
        //
    }

    [Serializable]
    internal class SqlExceptions : Exception
    {
        public SqlExceptions()
        {
        }

        public SqlExceptions(string? message) : base(message)
        {
        }

        public SqlExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SqlExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
