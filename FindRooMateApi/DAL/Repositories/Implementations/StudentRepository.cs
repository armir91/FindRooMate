using FindRooMateApi.DAL.Context;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FindRooMateApi.DAL.Repositories.Implementations;

public class StudentRepository : IStudentRepository
{

    protected FindRooMateContext _context;

    public StudentRepository(FindRooMateContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<Student> AddAsync(Student student)
    {
        var result = _context.Students.Add(student);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Student> DeleteAsync(int studentId)
    {
        var entity = await GetAsync(studentId);
        var result = _context.Students.Remove(entity);
        _ = await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> ExistAsync(string name, string surname)
    {
      var result = await  _context.Students.AnyAsync(s => s.Name== name && s.Surname == surname);

        return result;
    }

    public async Task<Student> GetAsync(int studentId)
    {
        var result = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        return result;
    }

    public async Task<List<Student>> GetAsync()
    {
        var result = await _context.Students.ToListAsync();
        return result;
    }

    public async Task<Student> UpdateAsync(Student student)
    {
        var result = _context.Students.Update(student);
        _ = await _context.SaveChangesAsync();
        return result.Entity;
    }
}
