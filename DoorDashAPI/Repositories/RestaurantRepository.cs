//using DoorDashAPI.DTOs;
using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DoorDashAPI.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DoorDashContext _context;
        public RestaurantRepository(DoorDashContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantAsync()
        {
            var restaurants = await _context.Restaurant.Include(r => r.Cuisines).ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            var data = await _context.Restaurant.Include(r => r.Dishes).Include(r => r.Cuisines).FirstOrDefaultAsync(r => r.RestaurantId == id);
            return data!;
        }

        public async Task AddRestaurantAsync(Restaurant restaurant)
        {
            await _context.Restaurant.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurant.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestaurantAsync(int id)
        {
            var restaurant = await GetRestaurantByIdAsync(id);
            if (restaurant != null)
            {
                _context.Restaurant.Remove(restaurant);
                await _context.SaveChangesAsync();

            }

        }
    }
}
