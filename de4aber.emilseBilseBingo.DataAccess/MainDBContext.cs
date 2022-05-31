using de4aber.emilseBilseBingo.Core.Models;
using de4aber.emilseBilseBingo.DataAcess.Entities;
using Microsoft.EntityFrameworkCore;

namespace de4aber.emilseBilseBingo.DataAcess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public virtual DbSet<PersonEntity> Persons { get; set; }

        public virtual DbSet<TileItemEntity> TileItemEntities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonEntity>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}