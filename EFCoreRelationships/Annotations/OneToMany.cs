using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationships.Annotations
{
    

    [Table("Authors")]
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // A "több" oldal: gyűjtemény navigáció
        public List<Book> Books { get; set; } = new();
    }

    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        // Idegen kulcs a szerzőre (az "egy" oldal)
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author Author { get; set; } = null!;
    }
}
