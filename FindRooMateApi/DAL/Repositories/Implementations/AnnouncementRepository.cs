using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindRooMateApi.DAL.Repositories.Implementations;


public class AnnouncementRepository : IAnnouncementRepository
{
    protected FindRooMateContext _context;

    public AnnouncementRepository(FindRooMateContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Announcement> AddAsync(Announcement announcement)
    {
        var result = _context.Announcements.Add(announcement);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Announcement> DeleteAsync(int announcementId)
    {
        var entity = await GetAsync(announcementId);
        var result = _context.Announcements.Remove(entity);
        _ = await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Announcement> GetActiveAsync(int announcementId)
    {
        var result = await _context.Announcements.FirstOrDefaultAsync(x => x.Id == announcementId && x.IsActive.Equals(true));
        return result;
    }    
    public async Task<Announcement> GetActiveAsyncwithRoom(int announcementId)
    {
        var result = await _context.Announcements.Include(x=>x.Room)
            .FirstOrDefaultAsync(x => x.Id == announcementId && x.IsActive.Equals(true));
        return result;
    }

    public async Task<Announcement> GetAsync(int announcementId)
    {
        var result = await _context.Announcements.FirstOrDefaultAsync(x => x.Id == announcementId);
        return result;
    }

    public async Task<List<Announcement>> GetAsync()
    {
        var result = await _context.Announcements.ToListAsync();
        return result;
    }

    public async Task<Announcement> UpdateAsync(Announcement announcement)
    {
        _context.Entry(announcement).State = EntityState.Modified;

        _ = await _context.SaveChangesAsync();

        return announcement;
    }

}
