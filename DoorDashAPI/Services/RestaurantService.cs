
using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorDashAPI.Services
{
    public class RestaurantService : IRestaurantRepository
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }


        // Get all restaurants
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantAsync()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurantAsync();
            var restaurantDtos = new List<Restaurant>();

            foreach (var restaurant in restaurants)
            {
                restaurantDtos.Add(new Restaurant
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    Area = restaurant.Area,
                    IsVeg = restaurant.IsVeg,
                    IsOpen = IsRestaurantOpen(restaurant.OpeningHour, restaurant.ClosingHour),
                    AverageRating = restaurant.AverageRating,
                    CostForTwo = restaurant.CostForTwo,
                    RestaurantImage = restaurant.RestaurantImage,
                    EstimatedDeliveryTime = restaurant.EstimatedDeliveryTime,

                });
            }
            return restaurantDtos;
        }

        // Get restaurant by id
        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);
            if (restaurant == null) return null!;

            return new Restaurant
            {
                RestaurantId = restaurant.RestaurantId,
                Name = restaurant.Name,
                Area = restaurant.Area,
                IsVeg = restaurant.IsVeg,
                IsOpen = IsRestaurantOpen(restaurant.OpeningHour, restaurant.ClosingHour),
                AverageRating = restaurant.AverageRating,
                CostForTwo = restaurant.CostForTwo,
                RestaurantImage = restaurant.RestaurantImage,
                EstimatedDeliveryTime = restaurant.EstimatedDeliveryTime,
            };
        }

        // Add a new restaurant
        public async Task<Restaurant> AddRestaurantAsync(Restaurant restaurantDto)
        {
            var restaurant = new Restaurant
            {
                Name = restaurantDto.Name,
                Area = restaurantDto.Area,
                City = restaurantDto.City,
                State = restaurantDto.State,
                IsVeg = restaurantDto.IsVeg,
                IsOpen = restaurantDto.IsOpen,
                OpeningHour = restaurantDto.OpeningHour,
                ClosingHour = restaurantDto.ClosingHour,
                AverageRating = restaurantDto.AverageRating,
                CostForTwo = restaurantDto.CostForTwo,
                ContactNumber = restaurantDto.ContactNumber,
                RestaurantImage = restaurantDto.RestaurantImage,
                EstimatedDeliveryTime = restaurantDto.EstimatedDeliveryTime,
            };
            var createdRestaurant = await _restaurantRepository.AddRestaurantAsync(restaurant);
            return restaurantDto;
        }

        // Update a restaurant
        public async Task<bool> UpdateRestaurantAsync(Restaurant restaurantDto)
        {
            var restaurant = new Restaurant
            {
                Name = restaurantDto.Name,
                Area = restaurantDto.Area,
                City = restaurantDto.City,
                State = restaurantDto.State,
                IsVeg = restaurantDto.IsVeg,
                IsOpen = restaurantDto.IsOpen,
                OpeningHour = restaurantDto.OpeningHour,
                ClosingHour = restaurantDto.ClosingHour,
                AverageRating = restaurantDto.AverageRating,
                CostForTwo = restaurantDto.CostForTwo,
                ContactNumber = restaurantDto.ContactNumber,
                RestaurantImage = restaurantDto.RestaurantImage,
                EstimatedDeliveryTime = restaurantDto.EstimatedDeliveryTime,
            };
            return await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }

        // Delete a restaurant
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            return await _restaurantRepository.DeleteRestaurantAsync(id);
        }

        // Check if restaurant is open
        private bool IsRestaurantOpen(TimeSpan openingTime, TimeSpan closingTime)
        {
            var currentTime = DateTime.Now.TimeOfDay;
            return currentTime >= openingTime && currentTime <= closingTime;
        }
    }
};
