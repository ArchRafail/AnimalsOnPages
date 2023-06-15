using AnimalsOnPages.Dtos;
using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IAnimalsRepository animalsRepository;

        public AnimalsService(IAnimalsRepository animalsRepository)
        {
            this.animalsRepository = animalsRepository;
        }

        public List<Animal> GetAll()
        {
            return animalsRepository.GetAll();
        }

        public Animal? Get(int? id)
        {
            var allAnimals = animalsRepository.GetAll();
            bool noSuchAnimal = true;
            if (id == null) { return null; }
            foreach (var animalFromList in allAnimals)
            {
                if (animalFromList.Id == id)
                {
                    noSuchAnimal = false;
                    break;
                }
            }
            if (noSuchAnimal) { return null; }
            return animalsRepository.Get((int)id);
        }

        public void Add(string classOfAnimal, AnimalDto animalDto)
        {
            if (AnimalNameWrong(animalDto)) { return; }
            if (AnimalSoundWrong(animalDto)) { return; }
            if (AnimalColorWrong(animalDto)) { return; }
            if (AnimalClassWrong(classOfAnimal)) { return; }
            Animal? animal = CreateAnimalAccordingClass(classOfAnimal, animalDto);
            if (animal == null)
            {
                return;
            }
            var allAnimals = animalsRepository.GetAll();
            if (allAnimals.Count == 0)
            {
                animalsRepository.Add(animal);
                return;
            }
            if (!allAnimals.Any(x => StringComparer.CurrentCultureIgnoreCase.Compare(x.Name, animal.Name) == 0))
            {
                animalsRepository.Add(animal);
            }
        }

        public void Update(string classOfAnimal, AnimalDto animalDto)
        {
            var allAnimals = animalsRepository.GetAll();
            bool noSuchAnimal = true;
            if (animalDto.Id == null) { return; }
            foreach (var animalFromList in allAnimals)
            {
                if (animalFromList.Id == animalDto.Id)
                {
                    noSuchAnimal = false;
                    break;
                }
            }
            if (noSuchAnimal) { return; }
            if (AnimalNameWrong(animalDto)) { return; }
            if (AnimalSoundWrong(animalDto)) { return; }
            if (AnimalColorWrong(animalDto)) { return; }
            if (AnimalClassWrong(classOfAnimal)) { return; }
            Animal oldAnimal = Get((int)animalDto.Id)!;
            Animal? animal = null;
            if (oldAnimal.AnimalClass != classOfAnimal)
            {
                animal = CreateAnimalAccordingClass(classOfAnimal, animalDto);
                if (animal != null)
                {
                    animal.Id = (int)animalDto.Id;
                }
                else
                {
                    return;
                }
            }
            if (animal == null)
            {
                animal = oldAnimal;
                animal.Id = oldAnimal.Id;
                animal.Name = animalDto.Name;
                animal.Sex = string.IsNullOrEmpty(animalDto.Sex) ? Sex.Male.ToString() : animalDto.Sex;
                animal.Rank = string.IsNullOrEmpty(animalDto.Rank) ? Rank.Herbivorous.ToString() : animalDto.Rank;
                animal.CoverColor = string.IsNullOrEmpty(animalDto.CoverColor) ? "No specified" : animalDto.CoverColor;
                animal.Sound = animalDto.Sound;
            }
            if (!allAnimals.Any(x => StringComparer.CurrentCultureIgnoreCase.Compare(x.Name, animal.Name) == 0))
            {
                animalsRepository.Update(animal);
            }
            if (allAnimals.Any(x => StringComparer.CurrentCulture.Compare(x.Name, animal.Name) == 0 && x.Id == animal.Id))
            {
                animalsRepository.Update(animal);
            }
        }

        public void Delete(int? id)
        {
            var allAnimals = animalsRepository.GetAll();
            bool noSuchAnimal = true;
            if (id == null) { return; }
            foreach (var animalFromList in allAnimals)
            {
                if (animalFromList.Id == id)
                {
                    noSuchAnimal = false;
                    break;
                }
            }
            if (noSuchAnimal) { return; }
            animalsRepository.Delete((int)id);
        }

        private Animal? CreateAnimalAccordingClass(string classOfAnimal, AnimalDto animalDto)
        {
            AnimalClass animalClassType;
            Animal? animal = null;
            int animalsCount = GetAll().Count;
            if (Enum.TryParse<AnimalClass>(classOfAnimal, out animalClassType))
            {
                switch (animalClassType)
                {
                    case AnimalClass.Mammal:
                        animal = new Mammal()
                        {
                            Id = animalsCount + 1,
                            Name = animalDto.Name,
                            Sex = string.IsNullOrEmpty(animalDto.Sex) ? Sex.Male.ToString() : animalDto.Sex,
                            Rank = string.IsNullOrEmpty(animalDto.Rank) ? Rank.Herbivorous.ToString() : animalDto.Rank,
                            CoverColor = string.IsNullOrEmpty(animalDto.CoverColor) ? "No specified" : animalDto.CoverColor,
                            Sound = animalDto.Sound
                        };
                        break;
                    case AnimalClass.Reptile:
                        animal = new Reptile()
                        {
                            Id = animalsCount + 1,
                            Name = animalDto.Name,
                            Sex = string.IsNullOrEmpty(animalDto.Sex) ? Sex.Male.ToString() : animalDto.Sex,
                            Rank = string.IsNullOrEmpty(animalDto.Rank) ? Rank.Carnivorous.ToString() : animalDto.Rank,
                            CoverColor = string.IsNullOrEmpty(animalDto.CoverColor) ? "No specified" : animalDto.CoverColor,
                            Sound = animalDto.Sound
                        };
                        break;
                    case AnimalClass.Amphibia:
                        animal = new Amphibia()
                        {
                            Id = animalsCount + 1,
                            Name = animalDto.Name,
                            Sex = string.IsNullOrEmpty(animalDto.Sex) ? Sex.Male.ToString() : animalDto.Sex,
                            Rank = string.IsNullOrEmpty(animalDto.Rank) ? Rank.Herbivorous.ToString() : animalDto.Rank,
                            CoverColor = string.IsNullOrEmpty(animalDto.CoverColor) ? "No specified" : animalDto.CoverColor,
                            Sound = animalDto.Sound
                        };
                        break;
                }
            }
            return animal;
        }

        private bool AnimalNameWrong(AnimalDto animalDto)
        {
            return string.IsNullOrEmpty(animalDto.Name) || animalDto.Name.Length < 3 || animalDto.Name.Length > 20;
        }

        private bool AnimalSoundWrong(AnimalDto animalDto)
        {
            return string.IsNullOrEmpty(animalDto.Sound) || animalDto.Sound.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries).Length is not 3;
        }

        private bool AnimalColorWrong(AnimalDto animalDto)
        {
            return !string.IsNullOrEmpty(animalDto.CoverColor) && (animalDto.CoverColor.Length < 3 || animalDto.CoverColor.Length > 20);
        }

        private bool AnimalClassWrong(string classOfAnimal)
        {
            return string.IsNullOrEmpty(classOfAnimal);
        }
    }
}
