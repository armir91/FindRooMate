using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Implementations;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.BLL.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IDormitoryRepository _dormitoryRepository;
        public RoomService(IRoomRepository roomRepository, IDormitoryRepository dormitoryRepository )
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _dormitoryRepository = dormitoryRepository;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            var result = await _roomRepository.GetAsync();

            return result;
        }

        //public async Task<Room> GetAsync();
        public async Task<int> AddAsync(string name, int dormitoryId, int capacity)
        {
                var dormitory = await _dormitoryRepository.GetAsync(dormitoryId);
                if (dormitory == null) {

                    throw new Exception("There was no dormitory found with the id passed"); 
                }

                var room = new Room
                {
                    Name = name,
                    DormitoryId = dormitory.Id,
                    Capacity = capacity

                };
                var result = await _roomRepository.AddAsync(room);
                return result.Id;
        }
    }
}
