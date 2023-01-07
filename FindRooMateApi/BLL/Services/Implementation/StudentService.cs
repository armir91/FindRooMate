using FindRooMateApi.BLL.DTO;
using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using FindRooMateApi.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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

    public async Task<List<StudentDTO>> GetAllAsync()
    {
        var result = await _studentRepository.GetAsync();
        var students = result.Select(p => new StudentDTO
        {
            Name = p.Name,
            Surname = p.Surname,
            Id = p.Id
        }).ToList();

        return students;
    }

    public async Task<Student> UpdateStudentAsync(int id, Student student)
    {
        var studentExist = await _studentRepository.GetAsync(id);

        if (studentExist != null)
        {
            studentExist.Name = student.Name;
            studentExist.Surname = student.Surname;

            await _studentRepository.UpdateAsync(student);

            var studentUpdate = await _studentRepository.GetAsync(id);

            return studentUpdate;
        }
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var studentExist = await _studentRepository.GetAsync(id);

        if (studentExist != null)
        {
            await _studentRepository.DeleteAsync(id);
            return true;

        }
        return false;
    }
}
