using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationships.Annotations
{
   

    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new();
    }

    [Table("Courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        public List<Student> Students { get; set; } = new();
    }
}
