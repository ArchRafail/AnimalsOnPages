using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsOnPages.Repositories
{
    public class ZoosRepository : IZoosRepository
    {
        private AnimalsDdContext _context;

        public ZoosRepository(AnimalsDdContext context)
        {
            _context = context;
        }

        public List<Zoo> GetAll()
        {
            return _context.Zoos.Include(x => x.Address).Include(x => x.Animals).ToList();
        }

        public Zoo Get(int id)
        {
            return _context.Zoos.Include(x => x.Address).Include(x => x.Animals).Single(x => x.Id == id);
        }

        public void Add(Zoo zoo)
        {
            var animals = zoo.Animals;
            zoo.Animals = null;
            _context.Zoos.Add(zoo);
            _context.SaveChanges();

            zoo = _context.Zoos.First(x => x.Name == zoo.Name);
            _context.ZoosAnimals.AddRange(animals.Select(
                x => new ZooAnimal()
                {
                    ZooId = zoo.Id,
                    AnimalId = x.Id
                }));
			_context.SaveChanges();
		}

        public void Update(Zoo zoo)
        {
            var animals = zoo.Animals;
            var oldZoo = Get(zoo.Id);
            if (oldZoo.Name != zoo.Name || oldZoo.AddressId != zoo.AddressId)
            {
                zoo.Animals = null;
                _context.Zoos.Update(zoo);
                _context.SaveChanges();
            }
            _context.ZoosAnimals.UpdateRange(animals.Select(
                x => new ZooAnimal()
                {
                    ZooId = zoo.Id,
                    AnimalId = x.Id
                }
                ));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var zooToDelete = Get(id);
            _context.Zoos.Remove(zooToDelete);
            _context.SaveChanges();
        }
    }
}
