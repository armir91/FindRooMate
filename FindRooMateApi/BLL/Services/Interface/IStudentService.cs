using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface;

public interface IStudentService
{
    Task<Student> AddAsync(string name, string surname);

    Task<List<Student>> GetAllAsync();

    Task<Student> GetByIdAsync(int id);

    Task<Student> Update(Student student);
    Task UpdateById(int id, Student student);
}
