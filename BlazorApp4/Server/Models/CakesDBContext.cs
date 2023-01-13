using BlazorApp4.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Server.Models
{
    public class CakesDBContext : DbContext
    {
        public CakesDBContext(DbContextOptions<CakesDBContext> options) 
            : base(options)
        {

        }

        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingerdients { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
