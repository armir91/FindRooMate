using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.BLL.Services.Implementation;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
    }

    public async Task<Student> AddAsync(string name, string surname)
    {
        // Check if student exist
        if (await _studentRepository.ExistAsync(name, surname))
        {
            throw new Exception("This user already exist!");
        }

        // Save user in database
        var student = new Student
        {
            Name = name,
            Surname = surname
        };

        var result = await _studentRepository.AddAsync(student);

        // Return saved user
        return result;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        var result = await _studentRepository.GetAsync();

        return result;
    }
}
