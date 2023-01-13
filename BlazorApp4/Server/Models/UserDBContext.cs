using BlazorApp4.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Server.Models
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => new { u.Email })
                .IsUnique();
        }
    }
}

    

