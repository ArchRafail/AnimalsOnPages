using AnimalsOnPages.Models;

namespace AnimalsOnPages.Interfaces
{
    public interface IAddressesRepository
    {
        List<Address> GetAll();

        void Add(Address address);

        Address Get(int id);

        void Update(Address address);

        void Delete(int id);
    }
}
