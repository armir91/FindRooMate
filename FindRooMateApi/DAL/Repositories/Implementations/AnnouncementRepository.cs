using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.DAL.Repositories.Implementations;


public class AnnouncementARepository : IAnnouncementRepository
{
    protected FindRooMateContext _context;

    public AnnouncementARepository(FindRooMateContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<Announcement> AddAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }

    public Task<Announcement> UpdateAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }

    Task<Announcement> IAnnouncementRepository.DeleteAsync(int announcementId)
    {
        throw new NotImplementedException();
    }

    Task<Announcement> IAnnouncementRepository.GetAsync(int announcementId)
    {
        throw new NotImplementedException();
    }

    Task<List<Announcement>> IAnnouncementRepository.GetAsync()
    {
        throw new NotImplementedException();
    }
}
