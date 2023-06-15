using AnimalsOnPages.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsOnPages.Repositories
{
    public class AnimalsDdContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ZooAnimal> ZoosAnimals { get; set; }

        public AnimalsDdContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amphibia>();
            modelBuilder.Entity<Mammal>();
            modelBuilder.Entity<Reptile>();

            modelBuilder.Entity<Zoo>()
                .HasOne(z => z.Address)
                .WithOne(a => a.Zoo)
                .HasForeignKey<Zoo>(z => z.AddressId);

            modelBuilder.Entity<Zoo>()
                .HasMany(z => z.Animals)
                .WithMany(a => a.Zoos)
                .UsingEntity<ZooAnimal>(x => x
                    .ToTable("ZooAnimal")
                );

            base.OnModelCreating(modelBuilder);
            new DBSeeding(modelBuilder).Seed();
        }
    }
}
