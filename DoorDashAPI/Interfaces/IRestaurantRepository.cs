using DoorDashAPI.Models;

namespace DoorDashAPI.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task<Restaurant> AddRestaurantAsync(Restaurant restaurant);
        Task<bool> UpdateRestaurantAsync(Restaurant restaurant);
        Task<bool> DeleteRestaurantAsync(int id);
    }
}

