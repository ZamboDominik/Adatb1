namespace EFCoreRelationships.Fluent
{
    // TÖBB-TÖBB (N:M) kapcsolat: egy diák több kurzusra járhat,
    // és egy kurzusra több diák is járhat.

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new();
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public List<Student> Students { get; set; } = new();
    }
}
