using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        
        public AppDbContext(DbContextOptions options ) : base(options)
        {
            
        }
    }
    
}