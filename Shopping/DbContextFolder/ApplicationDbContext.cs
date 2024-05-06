using Microsoft.EntityFrameworkCore;
using Shopping.Models;

namespace Shopping.DbContextFolder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        
      
        
        }
        public DbSet<Product> Products { get; set; }    
    }
}
