using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Repositories
{
    public class AddressesRepository : IAddressesRepository
    {
        private AnimalsDdContext _context;

        public AddressesRepository(AnimalsDdContext context)
        {
            _context = context;
        }

        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address Get(int id)
        {
            return _context.Addresses.Single(x => x.Id == id);
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var addressToDelete = Get(id);
            _context.Addresses.Remove(addressToDelete);
            _context.SaveChanges();
        }

    }
}
