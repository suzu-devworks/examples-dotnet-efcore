using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Examples.EntityFrameworkCore.TestDouble;

public static class SQLiteDbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder<TContext> UseTestInMemorySqlite<TContext>(this DbContextOptionsBuilder<TContext> options,
        string connectionString = "Filename=:memory:",
        Action<SqliteDbContextOptionsBuilder>? optionsAction = null)
        where TContext : DbContext
    {
        var connection = new SqliteConnection(connectionString);
        connection.Open();

        options.UseSqlite(connection, optionsAction);

        return options;
    }

}
