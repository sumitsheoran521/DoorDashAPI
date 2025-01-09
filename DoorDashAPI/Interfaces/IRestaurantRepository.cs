using DoorDashAPI.Models;

namespace DoorDashAPI.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int id);
    }
}

