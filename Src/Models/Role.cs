namespace AyundatiaUno.Src.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // EntityFramework
        public List<User> Users { get; set; } = new();
    }
}