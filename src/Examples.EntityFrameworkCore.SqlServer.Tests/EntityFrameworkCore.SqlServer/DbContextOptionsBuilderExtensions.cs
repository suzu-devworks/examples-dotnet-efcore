using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Examples.EntityFrameworkCore.SqlServer;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder<TContext> UseSqlServerDefault<TContext>(this DbContextOptionsBuilder<TContext> options,
        string? connectionString = null,
        Action<SqlServerDbContextOptionsBuilder>? optionsAction = null)
        where TContext : DbContext
        => (DbContextOptionsBuilder<TContext>)UseTestSqlServer((DbContextOptionsBuilder)options, connectionString, optionsAction);

    public static DbContextOptionsBuilder UseTestSqlServer(this DbContextOptionsBuilder options,
        string? connectionString = null,
        Action<SqlServerDbContextOptionsBuilder>? optionsAction = null)
    {
        connectionString ??= "Data Source=sqlserver;Initial Catalog=Examoples;User ID=sa;Password=sql2022@Password;Persist Security Info=False;TrustServerCertificate=yes";
        options.UseSqlServer(connectionString, optionsAction);

        return options;
    }

}
