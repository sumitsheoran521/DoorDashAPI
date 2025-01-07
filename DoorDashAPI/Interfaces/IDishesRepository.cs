using DoorDashAPI.Models;

namespace DoorDashAPI.Interfaces
{
    public interface IDishesRepository
    {
        Task<IEnumerable<Dish>> GetDishAsync();
        Task<Dish> GetDishByIdAsync(int id);
        Task<Dish> AddDishAsync(Dish dish);
        Task<bool> UpdateDishAsync(Dish dish);
        Task<bool> DeleteDishAsync(int id);
    }
}
