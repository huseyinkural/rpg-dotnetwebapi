using Microsoft.EntityFrameworkCore;
using rpg_webapi.Models;

namespace rpg_webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Weapon> Weapons { get; set; }
    }
}