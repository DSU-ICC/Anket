using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Anket.Models;

namespace Anket.DBService
{
    public class ApplicationContext : IdentityDbContext<Moderator>
    {
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Result> Results { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();   // удаляем базу данных при первом обращении
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
