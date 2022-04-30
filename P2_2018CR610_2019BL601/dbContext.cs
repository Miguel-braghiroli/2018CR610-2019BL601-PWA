using Microsoft.EntityFrameworkCore;
using P2_2018CR610_2019BL601.Models;

namespace P2_2018CR610_2019BL601
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Generos> generos { get; set; }
        public DbSet<Casos> casos { get; set; }
    }
}
