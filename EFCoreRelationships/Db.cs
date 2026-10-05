namespace EFCoreRelationships
{
    internal static class Db
    {
        
        public static string ConnectionString(string database) =>
            $"Server=localhost;Port=32770;Database={database};User=root;Password=Teszt123;";
    }
}
