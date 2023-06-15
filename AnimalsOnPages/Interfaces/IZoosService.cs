using AnimalsOnPages.Models;

namespace AnimalsOnPages.Interfaces
{
    public interface IZoosService
    {
        List<Zoo> GetAll();

        Zoo? Get(int? id);

        void Add(Zoo zoo);

        void Update(Zoo zoo);

        void Delete(int? id);
    }
}
