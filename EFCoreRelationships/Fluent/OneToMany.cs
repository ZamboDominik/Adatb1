namespace EFCoreRelationships.Fluent
{
   

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new();
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
