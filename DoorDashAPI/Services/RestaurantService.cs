using DoorDashAPI.Interface;
using DoorDashAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace DoorDashAPI.Service
{
    public class RestaurantService : IRestaunrant
    {
        private readonly DoorDashContext _context;

        public RestaurantService(DoorDashContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            try
            {
                var restaurants = await _context.Restaurant.Include(r => r.Cuisines).ToListAsync();

                restaurants.ForEach(r => r.UpdateIsOpenStatus());
                await _context.SaveChangesAsync();
                return restaurants;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving restaurants.", ex);
            }
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            try
            {
                var restaurant = await _context.Restaurant
                    .Include(r => r.Cuisines)
                    .Include(r => r.Dishes)
                    .FirstOrDefaultAsync(e => e.RestaurantId == id) 
                    ?? throw new AuthenticationException("No restaurant with this ID");
                
                if (restaurant == null)
                {
                    throw new InvalidOperationException("No restaurant found with this ID.");
                }
                restaurant.UpdateIsOpenStatus();
                await _context.SaveChangesAsync();
                return restaurant;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the restaurant by ID.", ex);
            }
        }

        public async Task<Restaurant> CreateRestaurant(Restaurant restaurant)
        {
            try
            {
                await _context.AddAsync(restaurant);
                await _context.SaveChangesAsync();
                return restaurant;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the restaurant.", ex);
            }
        }

        public async Task<Restaurant> UpdateRestaurant(int id, Restaurant restaurant)
        {
            try
            {
                var existingRestaurant = await _context.Restaurant.FirstOrDefaultAsync(e => e.RestaurantId == id);
                if (existingRestaurant == null)
                {
                    throw new InvalidDataException("No restaurant found with this ID.");
                }

                existingRestaurant.Name = restaurant.Name;
                existingRestaurant.Area = restaurant.Area;
                existingRestaurant.ContactNumber = restaurant.ContactNumber;
                existingRestaurant.IsVeg = restaurant.IsVeg;
                existingRestaurant.AverageRating = restaurant.AverageRating;
                existingRestaurant.CostForTwo = restaurant.CostForTwo;
                existingRestaurant.OpeningHour = restaurant.OpeningHour;
                existingRestaurant.ClosingHour = restaurant.ClosingHour;
                existingRestaurant.RestaurantImage = restaurant.RestaurantImage;
                existingRestaurant.City = restaurant.City;
                existingRestaurant.State = restaurant.State;
                existingRestaurant.RestaurantLink = restaurant.RestaurantLink;
                existingRestaurant.EstimatedDeliveryTime = restaurant.EstimatedDeliveryTime;

                // Update IsOpen status
                existingRestaurant.UpdateIsOpenStatus();

                await _context.SaveChangesAsync();
                return existingRestaurant;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the restaurant.", ex);
            }
        }

        public async Task<Restaurant> DeleteRestaurant(int id)
        {
            try
            {
                var restaurant = await _context.Restaurant.FirstOrDefaultAsync(e => e.RestaurantId == id);

                if (restaurant == null)
                {
                    throw new InvalidOperationException("No restaurant found with this ID.");
                }

                _context.Restaurant.Remove(restaurant);
                await _context.SaveChangesAsync();

                return restaurant;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the restaurant.", ex);
            }
        }
    }
};
