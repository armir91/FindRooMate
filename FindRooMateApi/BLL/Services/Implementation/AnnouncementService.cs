using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.BLL.Services.Implementation;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IRoomRepository _roomRepository;

    public AnnouncementService (IAnnouncementRepository announcementRepository, IRoomRepository roomReppository)
    {
       
        _announcementRepository= announcementRepository;
        _roomRepository= roomReppository;
    }

    public async Task<Announcement> AddAsync(string title, string description, int roomId)
    {
        var room = await _roomRepository.Exist(roomId);
        if(!room)
        {
            throw new Exception("Room doesn't exist");

        }
        var announcement = new Announcement
        {
            Title = title,
            Description = description,
            RoomId = roomId
        };
        var createdannouncement = await _announcementRepository.AddAsync(announcement);

        var result = await _announcementRepository.GetActiveAsyncwithRoom(createdannouncement.Id);

        return result;

    }

    public Task<Announcement> DeleteAsync(int announcementId)
    {
        throw new NotImplementedException();
    }

    public async Task<Announcement> GetAsync(int announcementId)
    {
        var result = await _announcementRepository.GetActiveAsync(announcementId); 
        return result;
    }

    public Task<List<Announcement>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Announcement> UpdateAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }
}
