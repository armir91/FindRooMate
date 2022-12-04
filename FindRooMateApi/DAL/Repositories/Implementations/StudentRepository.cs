using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;

namespace FindRooMateApi.DAL.Repositories.Implementations;

public class StudentRepository : IStudentRepository
{

    protected FindRooMateContext _context;

    public StudentRepository(FindRooMateContext context)
    {
        _context = context;
    }
    public async Task<Student> AddAsync(Student student)
    {
        var result = _context.Students.Add(student);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public Task DeleteAsync(int studentId)
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetAsync(int studentId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Student>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Student> UpdateAsync(string name, string surname)
    {
        throw new NotImplementedException();
    }
}
