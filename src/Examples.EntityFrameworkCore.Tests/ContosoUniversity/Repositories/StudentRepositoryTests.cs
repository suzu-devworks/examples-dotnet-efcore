using Examples.ContosoUniversity.Data;
using Examples.ContosoUniversity.Models;
using Examples.EntityFrameworkCore.InMemory;
using Examples.Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.ContosoUniversity.Repositories;

public class StudentRepositoryTests : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IStudentRepository _repository;

    public StudentRepositoryTests(ITestOutputHelper testOutputHelper)
    {
        var services = new ServiceCollection();
        services.AddLogging(builder
            => builder.AddXunitDebug(testOutputHelper));

        services.AddDbContext<SchoolContext>(options
            => options.UseInMemoryDatabaseDefault());

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
    public async Task WhenCallingFindAllAsync()
    {

        var records = await _repository.FindAllAsync();

        // Assertion.
        records.Count().Is(3);

        return;
    }

    [Fact]
    public async Task WhenCallingFindAsync()
    {
        var record = await _repository.FindAsync(1);

        // Assertion.
        record.IsNotNull();
        record!.ID.Is(1);

        return;
    }

    [Fact]
    public async Task WhenCallingAddAsync()
    {
        var input = new Student
        {
            FirstMidName = "Hoge",
            LastName = "Foo",
            EnrollmentDate = DateTime.Parse("2022-10-01")
        };

        await _repository.AddAsync(input);


        // Assertion.
        var records = await _repository.FindAllAsync();
        records.Count().Is(4);

        return;
    }


}
