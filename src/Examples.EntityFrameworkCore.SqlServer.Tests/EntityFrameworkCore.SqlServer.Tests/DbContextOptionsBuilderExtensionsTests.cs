using Examples.ContosoUniversity.Data;
using Examples.ContosoUniversity.Models;
using Examples.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.Articles.DbCapabilities;

public class DbContextOptionsBuilderExtensionsTests : IDisposable
{
    private readonly SchoolContext _context;

    public DbContextOptionsBuilderExtensionsTests()
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseSqlServer()
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
        _context.GetTableName(new Student()).Is("user.Students");
        _context.GetTableName(new Enrollment()).Is("user.Enrollments");
        _context.GetTableName(new Course()).Is("user.Courses");

        return;
    }
}
