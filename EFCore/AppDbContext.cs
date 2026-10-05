using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    internal class AppDbContext:DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connectionString = "Server=localhost;Port=32770;Database=sys;User=root;Password=Teszt123;";

            
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
