using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Implementations;
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
        //Check if student exist
        if (await _studentRepository.ExistAsync(name, surname))
        {
            throw new Exception("This user already exist!");
        }
        //Save user in DB
        var student = new Student
        {
            Name = name,
            Surname = surname
        };
        var result = await _studentRepository.AddAsync(student);

        //Return saved user
        return result;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        var result = await _studentRepository.GetAsync();

        return result;
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        var result = await _studentRepository.GetAsync(id);

        return result;
    }

    public async Task<Student> Update(Student student)
    {
        var result = await _studentRepository.UpdateAsync(student);
        return result;
    }
    public async Task<Student> UpdateById(int id, Student student)
    {
       ;
        Student student1 = await GetByIdAsync(id);
        if (student1 != null)
        {
            student1.Name = student.Name;
            student1.Surname = student.Surname;
        }
        return await Update(student);
    }

    Task IStudentService.UpdateById(int id, Student student)
    {
        throw new NotImplementedException();
    }
}
