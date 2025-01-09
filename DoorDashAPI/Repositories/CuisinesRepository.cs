using DoorDashAPI.Interfaces;
using DoorDashAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorDashAPI.Repositories
{
    public class CuisinesRepository : ICuisinesRepository
    {
        private readonly DoorDashContext _context;


        public CuisinesRepository(DoorDashContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cuisine>> GetCuisineAsync()
        {
            return await _context.Cuisine
                .Select(cuisine => new Cuisine
                {
                    CuisineId = cuisine.CuisineId,
                    CuisineName = cuisine.CuisineName,
                })
                .ToListAsync();
        }

        public async Task<Cuisine> GetCuisineByIdAsync(int id)
        {
            var cuisine =  await _context.Cuisine.FirstOrDefaultAsync(c => c.CuisineId == id);
            return cuisine!;
        }

        public async Task<bool> UpdateCuisineAsync(Cuisine cuisine)
        {
            _context.Cuisine.Update(cuisine);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Cuisine> AddCuisineAsync(Cuisine cuisine)
        {
            await _context.Cuisine.AddAsync(cuisine);
            await _context.SaveChangesAsync();
            return cuisine;
        }

        public async Task<bool> DeleteCuisineAsync(int id)
        {
            await _context.Cuisine.Where(c => c.CuisineId == id).ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
