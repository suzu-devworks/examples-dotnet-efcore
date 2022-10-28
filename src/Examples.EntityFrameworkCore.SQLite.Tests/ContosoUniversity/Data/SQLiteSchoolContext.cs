using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Data;

public class SQLiteSchoolContext : SchoolContext
{
    public SQLiteSchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }
}
