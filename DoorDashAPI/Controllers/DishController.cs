//using DoorDashAPI.DTOs;

using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorDashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishesRepository _dishService;

        public DishController(IDishesRepository dishService)
        {
            _dishService = dishService;
        }

        // GET: api/Dish
        [HttpGet]
        public async Task<ActionResult<Dish>> GetDishes()

        {
            try
            {
                var dish = await _dishService.GetDishAsync();
                if (dish == null || !dish.Any())
                {
                    return NotFound("No dishes available");
                }

                return Ok(dish);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Dish/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDishById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }
            try
            {
                var dish = await _dishService.GetDishByIdAsync(id);

                if (dish == null)
                {
                    return NotFound("Dish not found.");
                }

                return Ok(dish);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Dish
        [HttpPost]
        public async Task<ActionResult<Dish>> AddDish([FromBody] Dish dish)
        {
            try
            {
                var newDish = await _dishService.AddDishAsync(dish);
                return Ok(newDish);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Dish/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Dish>> UpdateDish(int id, Dish dish)
        {
            try
            {
                if (id != dish.DishId)
                {
                    return BadRequest("ID mismatch");
                }
                var updatedDish = await _dishService.UpdateDishAsync(dish);
                if (!updatedDish)
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

        // DELETE: api/Dish/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dish>> DeleteDish(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0.");
            }
            try
            {
                var dish = await _dishService.DeleteDishAsync(id);
                if (!dish)
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
