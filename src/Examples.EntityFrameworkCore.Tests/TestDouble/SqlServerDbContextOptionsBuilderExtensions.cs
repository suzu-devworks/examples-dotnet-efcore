using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Examples.EntityFrameworkCore.TestDouble;

public static class SqlServerDbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder<TContext> UseTestSqlServer<TContext>(this DbContextOptionsBuilder<TContext> options,
        string connectionString = "Data Source=sqlserver;Initial Catalog=Examoples;User ID=sa;Password=sql2022@Password;Persist Security Info=False",
        Action<SqlServerDbContextOptionsBuilder>? optionsAction = null)
        where TContext : DbContext
    {
        options.UseSqlServer(connectionString, optionsAction);

        return options;
    }
}
