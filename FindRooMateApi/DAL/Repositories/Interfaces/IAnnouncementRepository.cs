using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.DAL.Repositories.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<Announcement> AddAsync(Announcement announcement);
        Task<Announcement> UpdateAsync(Announcement announcement);
        Task<Announcement> DeleteAsync(int announcementId);
        Task<Announcement> GetAsync(int announcementId);
        Task<List<Announcement>> GetAsync();
    }
}
