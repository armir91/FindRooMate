using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface
{
    public interface IDormitoryService
    {
        Task<Dormitory> AddAsync(string code, string name, int maxcap);
        Task<List<Dormitory>> GetAllAsync();
        Task<Dormitory> GetAsync(int id);
    }
}
