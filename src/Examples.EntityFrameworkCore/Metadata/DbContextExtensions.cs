using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Examples.EntityFrameworkCore.Metadata;

public static class DbContextExtensions
{
    public static string? GetTableName<T>(this DbContext dbContext, T? _ = default)
    {
        var entityType = dbContext.FindEntityType<T>();
        if (entityType is null)
        {
            throw new InvalidOperationException($"IEntityType not found: Type=\"{typeof(T)}\".");
        }

        var fromClause = dbContext.Database.IsSchemaSupported()
            ? entityType.GetSchemaQualifiedTableName()
            : entityType.GetTableName();

        return fromClause;
    }

    private static bool IsSchemaSupported(this DatabaseFacade database)
    {
        var supported = (database.ProviderName == "Microsoft.EntityFrameworkCore.SqlServer");

        return supported;
    }


    public static IReadOnlyList<IProperty> FindPrimaryKeyProperties<T>(this DbContext dbContext, T? _ = default)
        => dbContext.FindEntityType<T>()?.FindPrimaryKey()?.Properties
            ?? Enumerable.Empty<IProperty>().ToList().AsReadOnly();


    public static IReadOnlyList<IProperty> FindProperties<T>(this DbContext dbContext, T? _, IEnumerable<string> propertyNames)
        => dbContext.FindEntityType<T>()?.FindProperties(propertyNames.ToList())
            ?? Enumerable.Empty<IProperty>().ToList().AsReadOnly();


    private static IEntityType? FindEntityType<T>(this DbContext dbContext)
        => dbContext.Model.FindEntityType(typeof(T));

}
