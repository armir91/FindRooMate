using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface;

public interface IStudentService
{
    Task<Student> AddAsync(string name, string surname);

    Task<List<Student>> GetAllAsync();

    Task<Student> UpdateStudentAsync(int id, Student student);

    Task<Student> DeleteAsync(int id);
}
