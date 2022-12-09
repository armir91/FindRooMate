using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface;

public interface IAnnouncementService
{
    Task<Announcement> AddAsync(Announcement announcement);
    Task<Announcement> UpdateAsync(Announcement announcement);
    Task<Announcement> DeleteAsync(int announcementId);
    Task<Announcement> GetAsync(int announcementId);
    Task<List<Announcement>> GetAsync();
}
