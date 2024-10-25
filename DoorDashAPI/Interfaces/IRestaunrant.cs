using DoorDashAPI.Models;

namespace DoorDashAPI.Interface
{
    public interface IRestaunrant
    {
        Task<List<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurantById(int id);
        Task<Restaurant> CreateRestaurant(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurant(int id, Restaurant restaurant);
        Task<Restaurant> DeleteRestaurant(int id);
    }
}
