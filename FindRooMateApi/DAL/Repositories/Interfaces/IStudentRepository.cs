using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.DAL.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> AddAsync(Student student);
    Task<Student> UpdateAsync(string name, string surname);  
    Task DeleteAsync(int studentId);
    Task<Student> GetAsync(int studentId);
    Task<List<Student>> GetAsync();

}