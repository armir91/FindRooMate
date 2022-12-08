using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface
{
    public interface IRoomService
    {
        Task<Room> AddAsync(string name, int dormitoryid, int capacity);
        
    }
}
