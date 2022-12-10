using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.DAL.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> AddAsync(Room room);
        Task<Room> UpdateAsync(Room room);
        Task<Room> DeleteAsync(int roomId);
        Task<Room> GetAsync(int roomId);
        Task<Room> GetRoomWithDormitoryAsync(int roomId);
        Task<List<Room>> GetAsync();
  
    }
}
