using Microsoft.EntityFrameworkCore;

namespace Examples.ContosoUniversity.Data;

public class SQLiteSchoolContext(DbContextOptions<SchoolContext> options) : SchoolContext(options)
{
}
