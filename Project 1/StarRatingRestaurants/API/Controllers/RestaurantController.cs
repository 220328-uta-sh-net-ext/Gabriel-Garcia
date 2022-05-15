using Microsoft.AspNetCore.Http;
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
        public RestaurantController(IRestaurantLogic _restLogic)
        {
            this._restLogic = _restLogic;
        }

        private static List<Restaurant> _restaurants = new List<Restaurant>
        {
            new Restaurant{Id = "id",Name = "name",Country = "c",State = "s",City = "cc",Zipcode = "z"},
            new Restaurant{Id = "id2",Name = "name2",Country = "c2",State = "s2",City = "cc2",Zipcode = "z2"}
        };
        //action methods: do things (get,put,post, delete, patch...)
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult< List<Restaurant>> Get()
        {
            var _rest = Ok( _restLogic.DisplayAllRestaurants());
            return Ok( _rest );
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
        public ActionResult Put([FromBody] Restaurant rest, string name)
        {
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
            restaur.Zipcode = rest.Zipcode;
            return Created("Get", rest);
        }
        [HttpDelete]
        public ActionResult Delete( string name)
        {
            if (name == null)
                return BadRequest("Cannot modify without name");
            var restaur = _restaurants.Find(x => x.Name.Contains(name));

            if (restaur == null)
            { return NotFound("Restaurant Not found "); }
            _restaurants.Remove(restaur);

            return Ok($"Restaurant {name} deleted ");
        }
        //
    }
}
