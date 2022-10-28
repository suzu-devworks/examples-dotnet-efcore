using Examples.EntityFrameworkCore.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Data;

/// <summary>
/// Design-time DbContext factory.
/// </summary>
/// <see href="https://learn.microsoft.com/ja-jp/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli" />
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SQLiteSchoolContext>
{
    public SQLiteSchoolContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseSqliteDefault()
            .Options;

        var context = new SQLiteSchoolContext(options);

        return context;
    }
}

