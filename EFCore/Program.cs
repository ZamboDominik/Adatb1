using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
        
            using var db = new AppDbContext();

      
            // 1. Create
            var newStudent = new Student
            {
                Name = "Kovács Péter",
                Email = "peter.kovacs@example.com",
                Age = 18
            };
            
            db.Students.Add(newStudent);
            await db.SaveChangesAsync();
            Console.WriteLine($"-> Létrehozva, ID: {newStudent.Id}\n");

            // 2. READ
            Console.WriteLine("2. Diákok listázása");
            var students = await db.Students.AsNoTracking().ToListAsync();

            foreach (var s in students)
            {
                Console.WriteLine($"   [{s.Id}] {s.Name} | {s.Email} | {s.Age} éves");
            }
            Console.WriteLine();

            // 3. UPDATE
            Console.WriteLine("3. Életkor frissítése");
            var studentToUpdate = await db.Students.FirstOrDefaultAsync(s => s.Id == newStudent.Id);

            if (studentToUpdate != null)
            {
                studentToUpdate.Age = 19;
                await db.SaveChangesAsync();
                Console.WriteLine($"-> {studentToUpdate.Name} módosított életkora: {studentToUpdate.Age}\n");
            }

            // 4. DELETE
            Console.WriteLine("4. Diák törlése");
            if (studentToUpdate != null)
            {
                db.Students.Remove(studentToUpdate);
                await db.SaveChangesAsync();
                Console.WriteLine("Rekord törölve az adatbázisból.");
            }

            Console.WriteLine("Kész! Nyomj egy gombot a kilépéshez...");
            Console.ReadKey();
        }
    }
}
