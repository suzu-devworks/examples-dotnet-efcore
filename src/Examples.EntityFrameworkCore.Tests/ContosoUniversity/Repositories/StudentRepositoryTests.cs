using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Examples.EntityFrameworkCore.ContosoUniversity.Data;
using Examples.EntityFrameworkCore.ContosoUniversity.Models;
using Examples.EntityFrameworkCore.Xunit;
using Xunit.Abstractions;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Repositories;

public class StudentRepositoryTests : IDisposable
{
    private readonly SchoolContext _context;
    private readonly StudentRepository _repository;

    public StudentRepositoryTests(ITestOutputHelper testOutputHelper)
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabase(nameof(StudentRepositoryTests))
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        var logFactory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Trace);
            builder.AddProvider(new XunitLoggerProvider(testOutputHelper));
        });

        var logger1 = logFactory.CreateLogger<SchoolContext>();
        _context = new SchoolContext(options, logger1);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _context.Students.AddRange(
            new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2019-09-01") },
            new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2017-09-01") },
            new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2018-09-01") }
        );
        _context.SaveChanges();

        var logger2 = logFactory.CreateLogger<StudentRepository>();
        _repository = new StudentRepository(_context, logger2);
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task Test1()
    {

        var records = await _repository.FindAllAsync();

        // Assertion.
        records.Count().Is(3);

        return;
    }
}
