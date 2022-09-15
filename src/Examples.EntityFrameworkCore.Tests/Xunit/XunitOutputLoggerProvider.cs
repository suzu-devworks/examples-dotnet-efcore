using Microsoft.Extensions.Logging;

namespace Examples.EntityFrameworkCore.Xunit;

/// <summary>
/// <see cref="ILoggerProvider" /> implementation for xunit.
/// </summary>
/// <examples>
/// <code>
/// dotnet test -l "console;verbosity=detailed"
/// </code>
/// </examples>
public class XunitOutputLoggerProvider : ILoggerProvider
{
    private readonly ITestOutputHelper _testOutputHelper;

    public XunitOutputLoggerProvider(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public ILogger CreateLogger(string categoryName)
        => new XunitLogger(_testOutputHelper, categoryName);

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }


    private class XunitLogger : ILogger
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly string _categoryName;

        public XunitLogger(ITestOutputHelper testOutputHelper, string categoryName)
        {
            _testOutputHelper = testOutputHelper;
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
          => NoopDisposable.Instance;

        public bool IsEnabled(LogLevel logLevel)
            => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            _testOutputHelper.WriteLine($"{_categoryName} [{eventId}] {formatter(state, exception)}");

            if (exception != null)
            {
                _testOutputHelper.WriteLine(exception.ToString());
            }

            return;
        }

    }

    private class NoopDisposable : IDisposable
    {
        public static NoopDisposable Instance = new();

        public void Dispose()
        {
        }
    }
}
