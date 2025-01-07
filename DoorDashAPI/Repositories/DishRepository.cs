using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorDashAPI.Repositories
{
    public class DishRepository: IDishesRepository
    {
        private readonly DoorDashContext _context;
        public DishRepository(DoorDashContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetDishAsync()
        {
            var dishes = await _context.Dish.ToListAsync();
            return dishes;
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            var dish = await _context.Dish.FindAsync(id);
            return dish!;
        }

        public async Task<bool> UpdateDishAsync(Dish dish)
        {
            _context.Dish.Update(dish);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Dish> AddDishAsync(Dish dish)
        {
            await _context.Dish.AddAsync(dish);
            await _context.SaveChangesAsync();
            return dish;
        }

        public async Task<bool> DeleteDishAsync(int id)
        {
            var dish = GetDishByIdAsync(id).Result;
            if (dish == null) return false;

            _context.Dish.Remove(dish);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
