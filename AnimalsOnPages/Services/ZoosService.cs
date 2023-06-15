using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Services
{
    public class ZoosService : IZoosService
    {
        private readonly IZoosRepository zoosRepository;

        public ZoosService(IZoosRepository zoosRepository)
        {
            this.zoosRepository = zoosRepository;
        }

        public List<Zoo> GetAll()
        {
            return zoosRepository.GetAll();
        }

        public Zoo? Get(int? id)
        {
            var allZoos = zoosRepository.GetAll();
            if (NoSuchZoo(allZoos, id)) { return null; }
            return zoosRepository.Get((int)id!);
        }

        public void Add(Zoo zoo)
        {
            if (string.IsNullOrEmpty(zoo.Name) || zoo.Name.Length < 3 || zoo.Name.Length > 40)
            {
                return;
            }
            var allZoos = zoosRepository.GetAll();

			if (allZoos.Count == 0)
            {
                zoosRepository.Add(zoo);
                return;
            }
            if (!allZoos.Any(x => StringComparer.CurrentCultureIgnoreCase.Compare(x.Name, zoo.Name) == 0))
            {
                zoosRepository.Add(zoo);
            }
        }

        public void Update(Zoo zoo)
        {
            var allZoos = zoosRepository.GetAll();
            if (NoSuchZoo(allZoos, zoo.Id)) { return; }
            if (string.IsNullOrEmpty(zoo.Name) || zoo.Name.Length < 3 || zoo.Name.Length > 40)
            {
                return;
            }
            if (allZoos.Any(x => StringComparer.CurrentCultureIgnoreCase.Compare(x.Name, zoo.Name) == 0 && x.Id != zoo.Id))
            {
               return;
            }
            zoosRepository.Update(zoo);
        }

        public void Delete(int? id)
        {
            var allZoos = zoosRepository.GetAll();
            if (NoSuchZoo(allZoos, id)) { return; }
            zoosRepository.Delete((int)id!);
        }

        private bool NoSuchZoo(List<Zoo> allZoos, int? zooId)
        {
            bool noSuchZoo = true;
            if (zooId == null)
            {
                return true;
            }
            foreach (var zooFromList in allZoos)
            {
                if (zooFromList.Id == zooId)
                {
                    noSuchZoo = false;
                    break;
                }
            }
            return noSuchZoo;
        }
    }
}
