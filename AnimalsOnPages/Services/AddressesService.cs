using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Services
{
    public class AddressesService : IAddressesService
    {
        private IAddressesRepository _repository;

        public AddressesService(IAddressesRepository addressesRepository)
        {
            _repository = addressesRepository;
        }

        public List<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public Address? Get(int? id)
        {
            var allAddresses = _repository.GetAll();
            if (NoSuchAddress(allAddresses, id)) { return null; }
            return _repository.Get((int)id!);
        }

        public void Add(Address address)
        {
            if (FieldLengthWrong(address.Country)) { return; }
            if (FieldLengthWrong(address.City)) { return; }
            if (FieldLengthWrong(address.Street)) { return; }
            if (address.Building < 1 || address.Building > 10000) { return; }

            var allAddresses = _repository.GetAll();
            if (allAddresses.Count == 0)
            {
                _repository.Add(address);
                return;
            }
            if (address.PostalCode != null && allAddresses.Any(x => x.PostalCode == address.PostalCode))
            {
                return;
            }
            foreach (var addressInList in allAddresses)
            {
                if (StringComparer.CurrentCultureIgnoreCase.Compare(addressInList.Country, address.Country) == 0
                    && StringComparer.CurrentCultureIgnoreCase.Compare(addressInList.City, address.City) == 0
                    && StringComparer.CurrentCultureIgnoreCase.Compare(addressInList.Street, address.Street) == 0
                    && addressInList.Building == address.Building)
                {
                    return;
                }
            }
            _repository.Add(address);

        }

        public void Update(Address address)
        {
            var allAddresses = _repository.GetAll();
            if (NoSuchAddress(allAddresses, address.Id)) { return; }
            if (FieldLengthWrong(address.Country)) { return; }
            if (FieldLengthWrong(address.City)) { return; }
            if (FieldLengthWrong(address.Street)) { return; }
            if (address.Building < 1 || address.Building > 10000) { return; }
            if (address.PostalCode != null && allAddresses.Any(x => x.PostalCode == address.PostalCode))
            {
                return;
            }
            foreach (var addressInList in allAddresses)
            {
                if (StringComparer.CurrentCultureIgnoreCase.Compare(addressInList.Country, address.Country) == 0
                    && StringComparer.CurrentCultureIgnoreCase.Compare(addressInList.City, address.City) == 0
                    && StringComparer.CurrentCultureIgnoreCase.Compare(addressInList.Street, address.Street) == 0
                    && addressInList.Building == address.Building
                    && addressInList.Id != address.Id)
                {
                    return;
                }
            }
            _repository.Update(address);
        }

        public void Delete(int? id)
        {
            var allAddresses = _repository.GetAll();
            if (NoSuchAddress(allAddresses, id)) { return; }
            _repository.Delete((int)id!);
        }

        private bool NoSuchAddress(List<Address> allAddresses, int? addressId)
        {
            bool noSuchAddress = true;
            if (addressId == null)
            {
                return true;
            }
            foreach (var zooFromList in allAddresses)
            {
                if (zooFromList.Id == addressId)
                {
                    noSuchAddress = false;
                    break;
                }
            }
            return noSuchAddress;
        }

        private bool FieldLengthWrong(string field)
        {
            return string.IsNullOrEmpty(field) || field.Length < 3 || field.Length > 20;
        }
    }
}
