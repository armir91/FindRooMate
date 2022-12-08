using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.BLL.Services.Implementation
{
    public class DormitoryService : IDormitoryService
    {
        public readonly IDormitoryRepository _dormitoryrepository;
        public DormitoryService(IDormitoryRepository dormitoryrepository)
        {
            _dormitoryrepository = dormitoryrepository ?? throw new ArgumentNullException(nameof(dormitoryrepository));
        }

        public async Task<Dormitory> AddAsync(string code, string name, int maxcap)
        {
            var dormitory = new Dormitory
            {
                Code= code,
                Name= name,
                MaxCapacity= maxcap
            };
            var result = await _dormitoryrepository.AddAsync(dormitory);

            return result;
        }

        public async Task<Dormitory> GetAsync(int id)
        {
            var result = await _dormitoryrepository.GetAsync(id);
            return result;
        }
    }
}
