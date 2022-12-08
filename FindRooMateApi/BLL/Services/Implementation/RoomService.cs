using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.BLL.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IDormitoryRepository _dormitoryRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }
        public Task<Room> AddAsync(string name, int dormitoryid, int capacity)
        {
            var room = new Room
            {
                Name = name,
                DormitoryId = dormitoryid,
                Capacity = capacity
                
            };
            return null;
        }
    }
}
