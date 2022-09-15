using Examples.EntityFrameworkCore.ContosoUniversity.Data;
using Examples.EntityFrameworkCore.ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.Sqlite;

public class DbContextExtensionsTests : IDisposable
{
    private readonly SchoolContext _context;

    public DbContextExtensionsTests()
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseSqlite()
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
        var context = _context;

        var studentTableName = context.GetTableName(new Student());
        var enrollmentTableName = context.GetTableName(new Enrollment());
        var courseTableName = context.GetTableName(new Course());

        studentTableName.Is("Students");
        enrollmentTableName.Is("Enrollments");
        courseTableName.Is("Courses");

        return;
    }

}
