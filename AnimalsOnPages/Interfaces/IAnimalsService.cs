using AnimalsOnPages.Dtos;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Interfaces
{
    public interface IAnimalsService
    {
        List<Animal> GetAll();

        Animal? Get(int? id);

        void Add(string classOfAnimal, AnimalDto animal);

        void Update(string classOfAnimal, AnimalDto animal);

        void Delete(int? id);
    }
}
