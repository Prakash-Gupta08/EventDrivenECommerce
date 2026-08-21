using EventDrivenECommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace EventDrivenECommerce.AppDBContext
{
    public class db_context : DbContext
    {
        public db_context(DbContextOptions<db_context> options) : base(options) { }

        public DbSet<Orders>Orders  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }

    }
}
