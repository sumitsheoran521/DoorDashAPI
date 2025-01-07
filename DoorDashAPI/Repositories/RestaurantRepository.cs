//using DoorDashAPI.DTOs;
using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorDashAPI.Repositories
{
    public class RestaurantRepository:IRestaurantRepository
    {
        private readonly DoorDashContext _context;
        public RestaurantRepository(DoorDashContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantAsync()
        {
            var restaurants = await _context.Restaurant.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            var data = await _context.Restaurant.FindAsync(id);
            return data!;
        }

        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurant)
        {
            await _context.Restaurant.AddAsync(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public async Task<bool> UpdateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurant.Update(restaurant);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var restaurant = await GetRestaurantByIdAsync(id);
            if (restaurant == null) return false;

            _context.Restaurant.Remove(restaurant);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
