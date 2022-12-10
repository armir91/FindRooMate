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
        public RoomService(IRoomRepository roomRepository, IDormitoryRepository dormitoryRepository)
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
        public async Task<Room> AddAsync(string name, int dormitoryId, int capacity)
        {
            var dormitoryExist = await _dormitoryRepository.Exist(dormitoryId);
            if (!dormitoryExist)
            {

                throw new Exception("There was no dormitory found with the id passed");
            }

            var room = new Room
            {
                Name = name,
                DormitoryId = dormitoryId,
                Capacity = capacity
            };

            var createdRoom = await _roomRepository.AddAsync(room);

            var result = await _roomRepository.GetRoomWithDormitoryAsync(createdRoom.Id);

            return result;
        }
    }
}
