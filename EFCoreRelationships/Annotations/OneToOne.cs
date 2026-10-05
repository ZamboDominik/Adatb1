using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationships.Annotations
{
    

    [Table("People")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        
        public Passport? Passport { get; set; }
    }

    [Table("Passports")]
    public class Passport
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Number { get; set; } = string.Empty;

       
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        public Person Person { get; set; } = null!;
    }
}
