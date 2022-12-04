using FindRooMateApi.BLL.Services.Interface;
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
    public async Task<IActionResult>Get()
    {
        var result = await _studentService.GetAllAsync();

        return Ok(result);
    }
}
