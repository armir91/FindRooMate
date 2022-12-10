using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindRooMateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly FindRooMateContext _context;

    public ApplicationController(FindRooMateContext findRooMateContext)
    {
        _context = findRooMateContext ?? throw new ArgumentNullException(nameof(findRooMateContext));
    }

    [HttpPut("Approve")]
    public async Task<IActionResult> Approve(int applicationId)
    {
        if (applicationId <= 0)
        {
            return BadRequest("Application id is not correct");
        }

        var roomStudent = await ApproveApplicationServiceAsync(applicationId);

        return Ok(roomStudent);
    }

    private async Task<RoomStudent> ApproveApplicationServiceAsync(int applicationId)
    {
        var existingApplication = await GetApplicationRepoAsync(applicationId);

        if (existingApplication == null)
        {
            throw new Exception("Application not found");
        }

        // Get student and room from application
        var studentId = existingApplication.StudentId;
        var roomId = existingApplication.Announcement.RoomId;

        // Create studentRoom in database
        var roomStudent = new RoomStudent
        {
            RoomId = roomId,
            StudentId = studentId,
        };

        var createdRoomStudent = await AddStudentRepoAsync(roomStudent);

        return createdRoomStudent;
    }

    private async Task<RoomStudent> AddStudentRepoAsync(RoomStudent roomStudent)
    {
        var result = await _context.RoomStudents.AddAsync(roomStudent);

        // Save database
        _ = await _context.SaveChangesAsync();

        // Return created student room
        return result.Entity;
    }

    private async Task<Application> GetApplicationRepoAsync(int applicationId)
    {
        // If application exist
        return await _context.Applications
            .Include(x => x.Announcement)
            .FirstOrDefaultAsync(x => x.Id == applicationId);
    }
}
