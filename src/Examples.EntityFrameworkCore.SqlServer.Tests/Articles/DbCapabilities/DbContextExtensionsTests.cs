using Examples.EntityFrameworkCore.ContosoUniversity.Data;
using Examples.EntityFrameworkCore.ContosoUniversity.Models;
using Examples.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.Articles.DbCapabilities;

public class DbContextExtensionsTests : IDisposable
{
    private readonly SchoolContext _context;

    public DbContextExtensionsTests()
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
