using Microsoft.EntityFrameworkCore;
using DomainService.Models;

namespace DomainService.DBService
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Result> Results { get; set; } = null!;
        public DbSet<TestingTeacher> TestingTeachers { get; set; } = null!;
        public DbSet<Employee> Moderators { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<OperationMode> OperationModes { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasOne(p => p.Question)
                .WithMany(t => t.ListAnswer)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Result>()
                .HasOne(p => p.Question)
                .WithMany(t => t.Results)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
