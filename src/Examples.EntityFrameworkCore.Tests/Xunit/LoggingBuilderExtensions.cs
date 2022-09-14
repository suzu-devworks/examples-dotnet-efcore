using Microsoft.Extensions.Logging;

namespace Examples.EntityFrameworkCore.Xunit;

public static class LoggingBuilderExtensions
{
    public static ILoggingBuilder AddXunitDefault(this ILoggingBuilder builder)
    {
        builder.SetMinimumLevel(LogLevel.Trace);
        builder
            .AddFilter("Default", LogLevel.Information)
            .AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("Microsoft.EntityFrameworkCore.Database", LogLevel.Information)
            .AddFilter("Examples", LogLevel.Trace);

        builder.AddDebug();

        return builder;
    }

}
