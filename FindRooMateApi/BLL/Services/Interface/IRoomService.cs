using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface
{
    public interface IRoomService
    {
        Task<int> AddAsync(string name, int dormitoryId, int capacity);
        Task<List<Room>> GetAllAsync();

    }
}
