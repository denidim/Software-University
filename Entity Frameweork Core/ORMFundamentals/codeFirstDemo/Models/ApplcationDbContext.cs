using Microsoft.EntityFrameworkCore;

namespace codeFirstDemo.Models
{
    public class ApplcationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.;Database=CodeFirstDemo2021;User Id=sa;Password=mssqlDB1;");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<News> News { get; set; }
    }
}
