using DoorDashAPI.Models;
using DoorDashAPI.Interfaces;

namespace DoorDashAPI.Services
{
    public class DishService : IDishesRepository
    {
        private readonly IDishesRepository _dishesRepository;
        public DishService(IDishesRepository dishesRepository)
        {
            _dishesRepository = dishesRepository;
        }

        public async Task<IEnumerable<Dish>> GetDishAsync()
        {
            var dishes = await _dishesRepository.GetDishAsync();
            var dishesDTO = new List<Dish>();
            foreach (var dish in dishes)
            {
                dishesDTO.Add(new Dish
                {
                    DishId = dish.DishId,
                    RestaurantId = dish.RestaurantId,
                    Name = dish.Name,
                    Description = dish.Description,
                    Price = dish.Price,
                    IsVeg = dish.IsVeg,
                    DishImg = dish.DishImg,
                    Rating = dish.Rating,
                });
            }
            return dishesDTO;
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            var dish = await _dishesRepository.GetDishByIdAsync(id);
            if (dish == null) return null!;
            return new Dish
            {
                DishId = dish.DishId,
                RestaurantId = dish.RestaurantId,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                IsVeg = dish.IsVeg,
                DishImg = dish.DishImg,
                Rating = dish.Rating,
            };
        }

        public async Task<Dish> AddDishAsync(Dish dishDto)
        {
            var dish = new Dish
            {
                DishId = dishDto.DishId,
                RestaurantId = dishDto.RestaurantId,
                Name = dishDto.Name,
                Description = dishDto.Description,
                Price = dishDto.Price,
                IsVeg = dishDto.IsVeg,
                DishImg = dishDto.DishImg,
                Rating = dishDto.Rating,
            };
            var createDish = await _dishesRepository.AddDishAsync(dish);
            return dishDto;
        }

        public async Task<bool> UpdateDishAsync(Dish dishDto)
        {
            var dish = new Dish
            {
                DishId = dishDto.DishId,
                RestaurantId = dishDto.RestaurantId,
                Name = dishDto.Name,
                Description = dishDto.Description,
                Price = dishDto.Price,
                IsVeg = dishDto.IsVeg,
                DishImg = dishDto.DishImg,
                Rating = dishDto.Rating,
            };
            return await _dishesRepository.UpdateDishAsync(dish);

        }

        public async Task<bool> DeleteDishAsync(int id)
        {
            return await _dishesRepository.DeleteDishAsync(id);
        }

        
    }
}
