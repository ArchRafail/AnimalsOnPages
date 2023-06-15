using AnimalsOnPages.Models;

namespace AnimalsOnPages.Interfaces
{
    public interface IAddressesService
    {
        List<Address> GetAll();

        Address? Get(int? id);

        void Add(Address address);

        void Update(Address address);

        void Delete(int? id);
    }
}
