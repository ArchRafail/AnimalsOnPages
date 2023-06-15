using AnimalsOnPages.Models;

namespace AnimalsOnPages.Interfaces
{
    public interface IZoosRepository
    {
        List<Zoo> GetAll();

        void Add(Zoo zoo);

        Zoo Get(int id);

        void Update(Zoo zoo);

        void Delete(int id);
    }
}
