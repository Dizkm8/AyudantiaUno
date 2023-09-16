using AyundatiaUno.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace AyundatiaUno.Src.Data
{
    public class DataContext : DbContext
    {
        // EntityFramework -> Crea la tabla Users -> Entidad User
        public DbSet<User> Users { get; set; } = null!;

        // EntityFramework -> Crea la tabla Roles -> Entidad Role

        public DbSet<Role> Roles { get; set; } = null!;

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}