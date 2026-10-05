namespace EFCoreRelationships.Fluent
{
   

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Passport? Passport { get; set; }
    }

    public class Passport
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }
}
