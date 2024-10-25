using DoorDashAPI.Models;

namespace DoorDashAPI.Interfaces
{
    public interface ICuisines
    {
        Task<IEnumerable<Cuisine>> GetCuisines();
        Task<Cuisine> GetCuisinesByID(int id);
        Task<Cuisine> CreateCuisine(Cuisine cuisine);
        Task<Cuisine> UpdateCuisine(int id, Cuisine cuisine);
        Task<Cuisine> DeleteCuisine(int id);
    }
}
