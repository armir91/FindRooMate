using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.DAL.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<Application> AddAsync(Application application);
        Task<Application> UpdateAsync(Application application);
        Task<Application> DeleteAsync(int applicationId);
        Task<Application> GetAsync(int applicationId);
        Task<List<Application>> GetAsync();
    }
}
