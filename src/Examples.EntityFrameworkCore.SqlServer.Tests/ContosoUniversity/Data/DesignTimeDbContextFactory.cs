using Examples.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Examples.ContosoUniversity.Data;

/// <summary>
/// Design-time DbContext factory.
/// </summary>
/// <see href="https://learn.microsoft.com/ja-jp/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli" />
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SqlServerSchoolContext>
{
    public SqlServerSchoolContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseSqlServerDefault()
            .Options;

        var context = new SqlServerSchoolContext(options);

        return context;
    }
}

