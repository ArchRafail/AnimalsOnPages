using AnimalsOnPages.Models;

namespace AnimalsOnPages.Interfaces
{
    public interface IAnimalsRepository
    {

        List<Animal> GetAll();

        void Add(Animal animal);

        Animal Get(int id);

        void Update(Animal animal);

    }
}
