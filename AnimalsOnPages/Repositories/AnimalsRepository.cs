using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private List<Animal> _animals;

        public AnimalsRepository()
        {
            _animals = new List<Animal>()
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

        }

        public List<Animal> GetAll()
        {
            return _animals;
        }

        public Animal Get(int id)
        {
            return _animals.Single(x=>x.Id == id);
        }

        public void Add(Animal animal)
        {
            _animals.Add(animal);
        }

        public void Update(Animal animal)
        {
            var animalToUpdate = Get(animal.Id);
            _animals.Remove(animalToUpdate);
            _animals.Insert(animal.Id-1, animal);
        }

        public void Delete(int id)
        {
            var animalToDelete = Get(id);
            _animals.Remove(animalToDelete);
        }
    }
}
