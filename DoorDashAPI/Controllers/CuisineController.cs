using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorDashAPI.Controllers
{
    [Route("api/[controller]")]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisinesRepository _cuisinesRepository;

        public CuisineController(ICuisinesRepository cuisinesRepository)
        {
            _cuisinesRepository = cuisinesRepository;
        }

        // GET: api/Cuisine
        [HttpGet]
        public async Task<ActionResult<Cuisine>> GetCuisines()

        {
            try
            {
                var cuisine = await _cuisinesRepository.GetCuisineAsync();
                if (cuisine == null || !cuisine.Any())
                {
                    return NotFound("No Cuisine available");
                }

                return Ok(cuisine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //GET: api/Cuisine/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuisine>> GetCuisineById(int id)
        {
            if (id < 0)
            {
                return BadRequest("ID must be greater than 0.");
            }
            try
            {
                var cuisine = await _cuisinesRepository.GetCuisineByIdAsync(id);
                if (cuisine == null)
                {
                    return NotFound("Cuisine not found.");
                }
                return Ok(cuisine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //POST: api/Cuisine
        [HttpPost]
        public async Task<ActionResult<Cuisine>> AddCuisine([FromBody] Cuisine cuisine)
        {
            try
            {
                if (cuisine == null)
                {
                    return BadRequest("Cuisine cannot be null.");
                }
                var createdCuisine = await _cuisinesRepository.AddCuisineAsync(cuisine);
                return Ok(createdCuisine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //PUT: api/Cuisine/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Cuisine>> UpdateCuisine(int id, Cuisine cuisine)
        {
            try
            {
                if (id < 0 || cuisine == null)
                {
                    return BadRequest("ID must be greater than 0 and Cuisine cannot be null.");
                }
                var updatedCuisine = await _cuisinesRepository.UpdateCuisineAsync(cuisine);
                if (!updatedCuisine)
                {
                    return NotFound("Cuisine not found.");
                }
                return Ok("Cuisine updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //DELETE: api/Cuisine/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cuisine>> DeleteCuisine(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("ID must be greater than 0.");
                }
                var deletedCuisine = await _cuisinesRepository.DeleteCuisineAsync(id);
                if (!deletedCuisine)
                {
                    return NotFound("Cuisine not found.");
                }
                return Ok("Cuisine deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
