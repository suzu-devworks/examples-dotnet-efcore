using Examples.EntityFrameworkCore.ContosoUniversity.Data;
using Examples.EntityFrameworkCore.ContosoUniversity.Models;
using Examples.EntityFrameworkCore.TestDouble;
using Examples.EntityFrameworkCore.Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Repositories;

public class StudentRepositoryTests : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IStudentRepository _repository;

    public StudentRepositoryTests(ITestOutputHelper testOutputHelper)
    {
        var services = new ServiceCollection();
        services.AddLogging(builder
            => builder.AddXunitDefault()
                .AddProvider(new XunitOutputLoggerProvider(testOutputHelper))
                );

        services.AddDbContext<SchoolContext>(options
            => options
                .UseInMemoryDatabase(nameof(StudentRepositoryTests))
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                );

        services.AddScoped<IStudentRepository, StudentRepository>();

        _serviceProvider = services.BuildServiceProvider();

        var context = _serviceProvider.GetRequiredService<SchoolContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Students.AddRange(
            new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2019-09-01") },
            new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2017-09-01") },
            new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2018-09-01") }
        );
        context.SaveChanges();

        _repository = _serviceProvider.GetRequiredService<IStudentRepository>();

    }

    public void Dispose()
    {
        (_serviceProvider as IDisposable)?.Dispose();
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

    [Fact]
    public async Task Test2()
    {

        var records = await _repository.FindAllAsync();

        // Assertion.
        records.Count().Is(3);

        return;
    }
}
