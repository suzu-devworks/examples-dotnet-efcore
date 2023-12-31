using Microsoft.EntityFrameworkCore;

namespace Examples.ContosoUniversity.Data;

public class SqlServerSchoolContext(DbContextOptions<SchoolContext> options) : SchoolContext(options)
{
}
