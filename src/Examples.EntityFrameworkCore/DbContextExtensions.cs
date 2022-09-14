using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Examples.EntityFrameworkCore;

public static class DbContextExtensions
{
    public static string? GetTableName<T>(this DbContext dbContext, T? _ = default)
    {
        var entityType = dbContext.FindEntityType<T>();
        if (entityType is null)
        {
            throw new InvalidOperationException($"IEntityType is not found: Type=\"{typeof(T)}\".");
        }

        var schema = entityType.GetSchema();
        var tableName = entityType.GetTableName();

        var fromClause = (schema is null) ? tableName : $"{schema}.{tableName}";

        return fromClause;
    }

    public static IReadOnlyList<IProperty> FindPrimaryKeyProperties<T>(this DbContext dbContext, T? _ = default)
        => dbContext.FindEntityType<T>()?.FindPrimaryKey()?.Properties
            ?? Enumerable.Empty<IProperty>().ToList().AsReadOnly();

    public static IReadOnlyList<IProperty> FindProperties<T>(this DbContext dbContext, T? _, IEnumerable<string> propertyNames)
        => dbContext.FindEntityType<T>()?.FindProperties(propertyNames.ToList())
            ?? Enumerable.Empty<IProperty>().ToList().AsReadOnly();

    private static IEntityType? FindEntityType<T>(this DbContext dbContext)
    {
        return dbContext.Model.FindEntityType(typeof(T));
    }

}
