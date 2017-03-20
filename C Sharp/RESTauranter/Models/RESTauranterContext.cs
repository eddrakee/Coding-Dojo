using Microsoft.EntityFrameworkCore;
 
namespace RESTauranter.Models
{
    public class RESTauranterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RESTauranterContext(DbContextOptions<RESTauranterContext> options) : base(options) { }

        // This creates a Reviews within the Db object
        public DbSet<Review> Reviews { get; set; }
    }
}