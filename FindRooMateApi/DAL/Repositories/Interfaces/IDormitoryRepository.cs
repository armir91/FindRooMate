using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.DAL.Repositories.Interfaces
{
    public interface IDormitoryRepository
    {
        Task<Dormitory> AddAsync(Dormitory dormitory);
        Task<Dormitory> UpdateAsync(Dormitory dormitory);
        Task<Dormitory> DeleteAsync(int dormitoryId);
        Task<Dormitory> GetAsync(int dormitoryId);
        Task<List<Dormitory>> GetAsync();

    }
}
