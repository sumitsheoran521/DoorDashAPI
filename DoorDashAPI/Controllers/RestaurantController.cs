using DoorDashAPI.Models;
using DoorDashAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace DoorDashAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly RestaurantService _restaurant;

        public RestaurantController(RestaurantService restaurant)
        {
            _restaurant = restaurant;
        }

        // GET: api/Restaurant
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
        {
            try
            {
                var allRestaurants = await _restaurant.GetRestaurants();

                if (allRestaurants == null || !allRestaurants.Any())
                {
                    return NotFound("No restaurant available for this location");
                }

                return Ok(allRestaurants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Restaurant/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }
            try
            {
                var restaurant = await _restaurant.GetRestaurantById(id);
                return Ok(restaurant);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task<ActionResult<Restaurant>> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                // Update IsOpen status before creating
                restaurant.UpdateIsOpenStatus();
                var createdRestaurant = await _restaurant.CreateRestaurant(restaurant);
                return Ok(createdRestaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Restaurant
        [HttpPut]
        public async Task<ActionResult<Restaurant>> UpdateRestaurant(int id, [FromBody] Restaurant restaurant)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }
            try
            {
                // Update IsOpen status before updating
                restaurant.UpdateIsOpenStatus();
                var res = await _restaurant.UpdateRestaurant(id, restaurant);
                return Ok(res);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Restaurant
        [HttpDelete]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }
            try
            {
                var restaurantToDelete = await _restaurant.DeleteRestaurant(id);
                if (restaurantToDelete == null)
                {
                    return NotFound($"Restaurant with ID {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
