using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Examples.EntityFrameworkCore.ContosoUniversity.Data;
using Examples.EntityFrameworkCore.ContosoUniversity.Models;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolContext _dbContext;
    private readonly ILogger<StudentRepository> _logger;

    public StudentRepository(SchoolContext dbContext, ILogger<StudentRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }


    public async Task<IEnumerable<Student>> FindAllAsync(CancellationToken cancelToken = default)
    {
        var students = await _dbContext.Students
            .ToListAsync(cancelToken);

        _logger.LogDebug("Students is founds: count=\"{count}\".", students.Count);

        return students;
    }

    public async Task<Student?> FindAsync(int id, CancellationToken cancelToken = default)
    {
        var student = await _dbContext.Students
            .FirstOrDefaultAsync(x => x.ID == id, cancelToken);

        if (student is null)
        {
            _logger.LogDebug("Students is not found.");
        }
        else
        {
            _logger.LogDebug("Students is found.");
        }

        return student;
    }

    public async Task AddAsync(Student student, CancellationToken cancelToken = default)
    {
        _dbContext.Add(student);
        await _dbContext.SaveChangesAsync(cancelToken);

        return;
    }

    public async Task ModifyAsync(int id, Student modifier, CancellationToken cancelToken = default)
    {
        if (id != modifier.ID)
        {
            throw new InvalidOperationException($"Invalid Student: id=\"{id}\".");
        }

        _dbContext.Update(modifier);
        await _dbContext.SaveChangesAsync(cancelToken);

        return;
    }

    public async Task RemoveAsync(int id, CancellationToken cancelToken = default)
    {
        var student = await _dbContext.Students
            .FirstOrDefaultAsync(x => x.ID == id, cancelToken);

        if (student is not null)
        {
            _dbContext.Remove(student!);
            await _dbContext.SaveChangesAsync(cancelToken);
        }

        return;
    }
}
