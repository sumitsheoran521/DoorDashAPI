using DoorDashAPI.Models;

namespace DoorDashAPI.Interfaces
{
    public interface ICuisinesRepository
    {
        Task<IEnumerable<Cuisine>> GetCuisineAsync();
        Task<Cuisine> GetCuisineByIdAsync(int id);
        Task<Cuisine> AddCuisineAsync(Cuisine cuisine);
        Task<bool> UpdateCuisineAsync(Cuisine cuisine);
        Task<bool> DeleteCuisineAsync(int id);
    }
}
