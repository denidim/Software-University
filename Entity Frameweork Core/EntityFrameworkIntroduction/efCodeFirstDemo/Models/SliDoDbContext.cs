using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace efCodeFirstDemo.Models
{
    internal class SliDoDbContext : DbContext
    {
        public SliDoDbContext()
        {

        }

        public SliDoDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SliDo;User Id=sa;Password=mssqlDB1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().Property(x => x.Content).IsUnicode(false);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Comment> Comments { get; set; }


        public DbSet<Question> Questions { get; set; }
    }
}
