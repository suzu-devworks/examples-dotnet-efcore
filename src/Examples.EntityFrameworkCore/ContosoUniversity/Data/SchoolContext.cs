using Examples.EntityFrameworkCore.ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Data;

public class SchoolContext : DbContext
{
    private readonly ILogger<SchoolContext> _logger;

    public SchoolContext(DbContextOptions<SchoolContext> options, ILogger<SchoolContext> logger)
        : base(options)
    {
        _logger = logger;
    }

    public override void Dispose()
    {
        _logger.LogTrace("Dispose called.");
        base.Dispose();
        GC.SuppressFinalize(this);
    }

    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Enrollment> Enrollments { get; set; } = default!;
    public DbSet<Course> Courses { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().ToTable("Students");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
        modelBuilder.Entity<Course>().ToTable("Courses");

        _logger.LogTrace("Model Created.");
        return;
    }

}
