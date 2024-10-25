using DoorDashAPI.Models;

namespace DoorDashAPI.Interfaces
{
    public interface IDishes
    {
        Task<IEnumerable<Dish>> GetDishes();
        Task<Dish> GetDishByID(int id);
        Task<Dish> CreateDish(Dish dish);
        Task<Dish> UpdateDish(int id, Dish dish);
        Task<Dish> DeleteDish(int id);
    }
}
