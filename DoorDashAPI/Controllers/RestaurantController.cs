using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorDashAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurant;

        public RestaurantController(IRestaurantRepository restaurant)
        {
            _restaurant = restaurant;
        }

        // GET: api/Restaurant
        [HttpGet]
        public async Task<ActionResult<Restaurant>> GetRestaurants()
        {
            try
            {
                var allRestaurants = await _restaurant.GetAllRestaurantAsync();

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
        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }
            try
            {
                var restaurant = await _restaurant.GetRestaurantByIdAsync(id);

                if (restaurant == null)
                {
                    return NotFound("Restaurant not found.");
                }

                return Ok(restaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task<IActionResult> AddRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                if (restaurant == null)
                {
                    return BadRequest();
                }
                await _restaurant.AddRestaurantAsync(restaurant);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Restaurant/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            try
            {
                if (id != restaurant.RestaurantId)
                {
                    return BadRequest("ID mismatch");
                }
                await _restaurant.UpdateRestaurantAsync(restaurant);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Restaurant
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }
            try
            {
                await _restaurant.DeleteRestaurantAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
