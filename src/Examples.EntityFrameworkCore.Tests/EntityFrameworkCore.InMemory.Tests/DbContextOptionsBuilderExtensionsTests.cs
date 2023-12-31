using Examples.ContosoUniversity.Data;
using Examples.ContosoUniversity.Models;
using Examples.EntityFrameworkCore.InMemory;
using Examples.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.Articles.DbCapabilities;

public class DbContextOptionsBuilderExtensionsTests : IDisposable
{
    private readonly SchoolContext _context;

    public DbContextOptionsBuilderExtensionsTests()
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabaseDefault()
            .Options;

        _context = new SchoolContext(options);
    }

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }


    [Fact]
    public void WnenCallingGetTableName()
    {
        _context.GetTableName(new Student()).Is("Students");
        _context.GetTableName(new Enrollment()).Is("Enrollments");
        _context.GetTableName(new Course()).Is("Courses");

        return;
    }

}
