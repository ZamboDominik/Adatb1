using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationships.Fluent
{
    
    internal class FluentDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public DbSet<Passport> Passports => Set<Passport>();

        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Db.ConnectionString("relationships_fluent"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1:1 
            modelBuilder.Entity<Person>(e =>
            {
                e.ToTable("People");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Passport>(e =>
            {
                e.ToTable("Passports");
                e.HasKey(p => p.Id);
                e.Property(p => p.Number).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Passport)                 
                .WithOne(p => p.Person)                 
                .HasForeignKey<Passport>(p => p.PersonId) 
                .OnDelete(DeleteBehavior.Cascade);       

            // 1:N 
            modelBuilder.Entity<Author>(e =>
            {
                e.ToTable("Authors");
                e.HasKey(a => a.Id);
                e.Property(a => a.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(e =>
            {
                e.ToTable("Books");
                e.HasKey(b => b.Id);
                e.Property(b => b.Title).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)         
                .WithOne(b => b.Author)         
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // N:M 
            modelBuilder.Entity<Student>(e =>
            {
                e.ToTable("Students");
                e.HasKey(s => s.Id);
                e.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.ToTable("Courses");
                e.HasKey(c => c.Id);
                e.Property(c => c.Title).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)      
                .WithMany(c => c.Students)      
                .UsingEntity(j => j.ToTable("StudentCourses"));
        }
    }
}
