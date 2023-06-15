using AnimalsOnPages.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsOnPages.Repositories
{
    public class DBSeeding
    {
        private readonly ModelBuilder modelBuilder;

        public DBSeeding(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            List<Address> addresses = new List<Address>()
            {
                new Address()
                {
                    Id = 1,
                    PostalCode = 76002,
                    Country = "Ukraine",
                    City = "Ivano-Frankivsk",
                    Street = "Uhornytska str.",
                    Building = 24
                },
                new Address()
                {
                    Id = 2,
                    PostalCode = 24431,
                    Country = "Ukraine",
                    City = "Kherson",
                    Street = "Nezalezhnosti str.",
                    Building = 18
                },
                new Address()
                {
                    Id = 3,
                    PostalCode = 22905,
                    Country = "Ukraine",
                    City = "Odessa",
                    Street = "Peremohy blr.",
                    Building = 178
                },
                new Address()
                {
                    Id = 4,
                    PostalCode = 10260,
                    Country = "Poland",
                    City = "Krakiv",
                    Street = "Perelutsk str.",
                    Building = 277
                },
                new Address()
                {
                    Id = 5,
                    PostalCode = 11713,
                    Country = "Poland",
                    City = "Lodz",
                    Street = "Stratvens str.",
                    Building = 143
                }
            };

            modelBuilder.Entity<Address>().HasData(
                addresses[0],
                addresses[1],
                addresses[2],
                addresses[3],
                addresses[4]
            );

            List<Zoo> zoos = new List<Zoo>()
            {
                new Zoo()
                {
                    Id= 1,
                    Name = "Carpathian National Nature Park",
                    AddressId = addresses[0].Id
                },
                new Zoo()
                {
                    Id = 2,
                    Name = "The country of Enotia",
                    AddressId = addresses[1].Id
                },
                new Zoo()
                {
                    Id = 3,
                    Name = "Odesa Zoo",
                    AddressId = addresses[2].Id
                },
                new Zoo()
                {
                    Id = 4,
                    Name = "Krakow Zoo",
                    AddressId = addresses[3].Id
                },
                new Zoo()
                {
                    Id = 5,
                    Name = "Royal Lazenky",
                    AddressId = addresses[4].Id
                }
            };

            modelBuilder.Entity<Zoo>().HasData(
                zoos[0],
                zoos[1],
                zoos[2],
                zoos[3],
                zoos[4]
            );

            List<Animal> animals = new List<Animal>()
            {
                new Mammal()
                {
                    Id = 1,
                    Name = "Wolf",
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "Grey",
                    Sound = "Owoo-oo-oo"
                },
                new Mammal()
                {
                    Id = 2,
                    Name = "Bear",
                    Sex = "Female",
                    Rank = "Carnivorous",
                    CoverColor = "BrownBrown",
                    Sound = "Ur-r-r"
                },
                new Reptile()
                {
                    Id = 3,
                    Name = "Crocodile",
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "LightGrey",
                    Sound = "Grunt, grunt, grunt"
                },
                new Reptile()
                {
                    Id = 4,
                    Name = "Turtle",
                    Sex = "Female",
                    Rank = "Herbivorous",
                    CoverColor = "LightGrey",
                    Sound = "Creek, creek, creek"
                },
                new Amphibia()
                {
                    Id = 5,
                    Name = "Frog",
                    Sex = "Female",
                    Rank = "Herbivorous",
                    CoverColor = "Green",
                    Sound = "Kwa, kwa, kwa"
                }
            };

            modelBuilder.Entity<Mammal>().HasData(
                animals[0],
                animals[1]
            );
            modelBuilder.Entity<Reptile>().HasData(
                animals[2],
                animals[3]
            );
            modelBuilder.Entity<Amphibia>().HasData(
                animals[4]
            );

            modelBuilder.Entity<ZooAnimal>().HasData(
                new ZooAnimal()
                {
                    Id = 1,
                    ZooId = zoos[0].Id,
                    AnimalId = animals[0].Id
                },
                new ZooAnimal()
                {
                    Id = 2,
                    ZooId = zoos[0].Id,
                    AnimalId = animals[2].Id
                },
                new ZooAnimal()
                {
                    Id = 3,
                    ZooId = zoos[0].Id,
                    AnimalId = animals[3].Id
                },
                new ZooAnimal()
                {
                    Id = 4,
                    ZooId = zoos[1].Id,
                    AnimalId = animals[0].Id
                },
                new ZooAnimal()
                {
                    Id = 5,
                    ZooId = zoos[1].Id,
                    AnimalId = animals[1].Id
                },
                new ZooAnimal()
                {
                    Id = 6,
                    ZooId = zoos[2].Id,
                    AnimalId = animals[2].Id
                },
                new ZooAnimal()
                {
                    Id = 7,
                    ZooId = zoos[2].Id,
                    AnimalId = animals[4].Id
                },
                new ZooAnimal()
                {
                    Id = 8,
                    ZooId = zoos[3].Id,
                    AnimalId = animals[1].Id
                },
                new ZooAnimal()
                {
                    Id = 9,
                    ZooId = zoos[3].Id,
                    AnimalId = animals[2].Id
                },
                new ZooAnimal()
                {
                    Id = 10,
                    ZooId = zoos[4].Id,
                    AnimalId = animals[2].Id
                },
                new ZooAnimal()
                {
                    Id = 11,
                    ZooId = zoos[4].Id,
                    AnimalId = animals[3].Id
                },
                new ZooAnimal()
                {
                    Id = 12,
                    ZooId = zoos[4].Id,
                    AnimalId = animals[4].Id
                }
            );
        }
    }
}
