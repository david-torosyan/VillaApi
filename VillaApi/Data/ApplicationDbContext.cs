using Microsoft.EntityFrameworkCore;
using VillaApi.Models;

namespace VillaApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(

                new Villa { Id = 1, Name = "Pool View" ,DisplayOrder = 1},
                new Villa { Id = 2, Name = "Beach View", DisplayOrder = 2 }

                );
        }
    }
}
