using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Data;

public class SqlServerSchoolContext : SchoolContext
{
    public SqlServerSchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }
}
