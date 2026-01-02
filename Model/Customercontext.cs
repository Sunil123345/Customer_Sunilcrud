using Microsoft.EntityFrameworkCore;

namespace CustomerReactiveForms.Model
{
    public class Customercontext:DbContext
    {
        public Customercontext(DbContextOptions<Customercontext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<CIty> Cities { get; set; }
    }
}
