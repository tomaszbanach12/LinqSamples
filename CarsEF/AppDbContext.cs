using Microsoft.EntityFrameworkCore;

namespace CarsEF
{
    class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LinqSamples;Integrated Security=True");
        }
    }
}
