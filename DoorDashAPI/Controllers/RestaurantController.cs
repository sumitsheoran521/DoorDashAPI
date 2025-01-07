﻿using DoorDashAPI.Interfaces;
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
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
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
        public async Task<ActionResult<Restaurant>> AddRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                var newRestaurant = await _restaurant.AddRestaurantAsync(restaurant);
                return Ok(newRestaurant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Restaurant/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            try
            {
                if (id != restaurant.RestaurantId)
                {
                    return BadRequest("ID mismatch");
                }
                var res = await _restaurant.UpdateRestaurantAsync(restaurant);
                if (!res)
                {
                    NotFound("Restaurant not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Restaurant
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }
            try
            {
                var result = await _restaurant.DeleteRestaurantAsync(id);
                if (!result)
                {
                    return NotFound("Dish not found");
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
