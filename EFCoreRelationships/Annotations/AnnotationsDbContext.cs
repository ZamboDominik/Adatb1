using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Annotations
{
    
    internal class AnnotationsDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Passport> Passports => Set<Passport>();

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Db.ConnectionString("relationships_annotations"));
        }
    }
}
