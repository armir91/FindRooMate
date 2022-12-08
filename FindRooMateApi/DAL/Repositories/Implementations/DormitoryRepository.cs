using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Xml.Linq;

namespace FindRooMateApi.DAL.Repositories.Implementations
{
    public class DormitoryRepository : IDormitoryRepository
    {
        protected FindRooMateContext _context;

        public DormitoryRepository(FindRooMateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Dormitory> AddAsync(Dormitory dormitory)
        {
            var result = _context.Dormitories.Add(dormitory);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Dormitory> DeleteAsync(int dormitoryId)
        {
            var entity = await GetAsync(dormitoryId);
            var result = _context.Dormitories.Remove(entity);
            _ = await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Exist(string name, string code)
        {
            var result = await _context.Dormitories.AnyAsync(s=> s.Name == name && s.Code == code);
            return result;
        }

        public Task<bool> Exist(int id)
        {
            var result =  _context.Dormitories.AnyAsync(s=>s.Id==id);
            return result;
        }

        public async Task<Dormitory> GetAsync(int dormitoryId)
        {
            var result = await _context.Dormitories.FirstOrDefaultAsync(s => s.Id == dormitoryId);
            return result;
        }

        public async Task<List<Dormitory>> GetAsync()
        {
            var result = await _context.Dormitories.ToListAsync();
            return result;
        }

        public async Task<Dormitory> UpdateAsync(Dormitory dormitory)
        {
            var result = _context.Dormitories.Update(dormitory);
            _ = await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
