using FindRooMateApi.DAL.Entities;

namespace FindRooMateApi.DAL.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> AddAsync(Student student);
    Task<Student> UpdateAsync(int id, Student student);
    Task<Student> DeleteAsync(int studentId);
    Task<Student> GetAsync(int studentId);
    Task<List<Student>> GetAsync();
    Task<bool> ExistAsync(string name, string surname);
}