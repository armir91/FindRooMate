using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.BLL.Services.Interface;

public interface IStudentService
{
    Task<Student> AddAsync(string name, string surname);

    Task<List<Student>> GetAllAsync();

    Task<Student> GetByIdAsync(int id);
  
    Task<Student> UpdateAsyc(Student student);
    Task<Student> UpdateAsyc(int id, string name, string surname);
}
