using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FindRooMateApi.DAL.Repositories.Implementations;

public class RoomRepository : IRoomRepository
{
    protected FindRooMateContext _context;

    public RoomRepository(FindRooMateContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Room> AddAsync(Room room)
    {
        var result = _context.Rooms.Add(room);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }


    public async Task<Room> DeleteAsync(int roomId)
    {
        var entity = await GetAsync(roomId);
        var result = _context.Rooms.Remove(entity);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Room> GetAsync(int roomId)
    {
        var result = await _context.Rooms.FirstOrDefaultAsync(s => s.Id == roomId);

        return result;
    }

    public async Task<Room> GetRoomWithDormitoryAsync(int roomId)
    {
        var result = await _context.Rooms
            .Include(x => x.Dormitory)
            .FirstOrDefaultAsync(s => s.Id == roomId);

        return result;
    }

    public async Task<List<Room>> GetAsync()
    {
        var result = await _context.Rooms.ToListAsync();
        return result;
    }

    public async Task<Room> UpdateAsync(Room room)
    {
        var result = _context.Rooms.Update(room);
        _ = await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Exist(int roomId)
    {
        var result = await _context.Rooms.AnyAsync(s => s.Id == roomId );

        return result;
    }
}
