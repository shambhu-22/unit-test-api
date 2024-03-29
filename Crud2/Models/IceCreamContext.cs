using Microsoft.EntityFrameworkCore;
namespace Crud2.Models
{
    public class IceCreamContext : DbContext
    {
        public IceCreamContext(DbContextOptions<IceCreamContext> options) : base(options)
        {

        }
        public DbSet<IceCream> IceCreamItems { get; set; }
        public DbSet<IceCreamImages> IceCreamImages { get; set; }
    }
}
