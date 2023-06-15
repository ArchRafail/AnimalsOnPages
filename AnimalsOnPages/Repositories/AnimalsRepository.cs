using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsOnPages.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private AnimalsDdContext _context;

        public AnimalsRepository(AnimalsDdContext context)
        {
            _context = context;
        }

        public List<Animal> GetAll()
        {
            var addresses = _context.Addresses.ToList();
			var ret = _context.Animals.Include(a => a.Zoos).ToList();

            foreach (var animal in ret) {
                foreach (var zoo in animal.Zoos!) {
					zoo.Address = addresses.FirstOrDefault(x=>x.Id == zoo.AddressId)!;
				}
            }
            return ret;

		}

        public Animal Get(int id)
        {
            var addresses = _context.Addresses.ToList();
            var ret = _context.Animals.Include(a => a.Zoos).Single(x => x.Id == id);
            foreach (var zoo in ret.Zoos!)
            {
                zoo.Address = addresses.FirstOrDefault(x => x.Id == zoo.AddressId)!;
            }
            return ret;
        }

        public void Add(Animal animal)
        {
            var zoos = animal.Zoos;
            animal.Zoos = null;
            _context.Animals.Add(animal);
            _context.SaveChanges();

            animal = _context.Animals.First(x => x.Name == animal.Name);
            _context.ZoosAnimals.AddRange(zoos.Select(
                x => new ZooAnimal()
                {
                    ZooId = x.Id,
                    AnimalId = animal.Id
                }));
            _context.SaveChanges();
        }

        public void Update(Animal animal)
        {
            var zoos = animal.Zoos;
            var oldAnimal = Get(animal.Id);
            animal.Zoos = null;
            oldAnimal.Zoos = null;
            if (oldAnimal != animal)
            {
                _context.Animals.Update(animal);
                _context.SaveChanges();
            }
            _context.ZoosAnimals.UpdateRange(zoos.Select(
                x => new ZooAnimal()
                {
                    ZooId = x.Id,
                    AnimalId = animal.Id
                }
                ));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var animalToDelete = Get(id);
            _context.Animals.Remove(animalToDelete);
            _context.SaveChanges();
        }
    }
}
