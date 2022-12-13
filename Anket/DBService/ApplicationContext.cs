using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Anket.Models;

namespace Anket.DBService
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Question> Disciplines { get; set; } = null!;
        public DbSet<Answer> Profiles { get; set; } = null!;
        public DbSet<Result> FileModels { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();   // удаляем базу данных при первом обращении
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
