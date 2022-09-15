using Examples.EntityFrameworkCore.ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public override void Dispose()
    {
        System.Diagnostics.Debug.WriteLine("Dispose called.");
        base.Dispose();
        GC.SuppressFinalize(this);
    }

    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Enrollment> Enrollments { get; set; } = default!;
    public DbSet<Course> Courses { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().ToTable("Students", "user");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollments", "user");
        modelBuilder.Entity<Course>().ToTable("Courses", "user");

        return;
    }

}
