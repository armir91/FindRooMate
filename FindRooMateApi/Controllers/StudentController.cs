using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindRooMateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(string name, string surname)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
        {
            return BadRequest("Please provide all information for student!");
        }
        var createdStudent = await _studentService.AddAsync(name, surname);
        return Ok(createdStudent);

    }

    [HttpGet("read")]
    public async Task<IActionResult> Get()
    {
        var result = await _studentService.GetAllAsync();

        return Ok(result);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        var updateStudent = await _studentService.UpdateStudentAsync(id, student);
        return Ok(updateStudent);
    }

    [HttpDelete("Delete-Student/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _studentService.DeleteAsync(id);
        if (isDeleted)
        {

            return Ok($"Student with id {id} deleted successfully.");
        }
        else
        {
            return BadRequest("Problems during delete!");
        }
    }
}
