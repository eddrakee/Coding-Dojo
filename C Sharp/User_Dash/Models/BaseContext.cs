using Microsoft.EntityFrameworkCore;
 
namespace UserDash.Models
{
    public class BaseContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        // Add in what you need to have access to below
        // public DbSet<Transaction> Transactions { get; set; }
    }
}
