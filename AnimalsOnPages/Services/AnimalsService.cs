using AnimalsOnPages.Dtos;
using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;

namespace AnimalsOnPages.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IAnimalsRepository _repository;

        public AnimalsService(IAnimalsRepository animalRepository)
        {
            _repository = animalRepository;
        }

        public List<Animal> GetAll()
        {
            return _repository.GetAll();
        }

        public Animal Get(int id)
        {
            return _repository.Get(id);
        }

        public void Add(string classOfAnimal, AnimalDto animalDto)
        {
            AnimalClass animalClassType;
            Animal animal = null;
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
                            Sex = animalDto.Sex,
                            Rank = animalDto.Rank,
                            CoverColor = animalDto.CoverColor,
                            Sound = animalDto.Sound
                        };
                        break;
                    case AnimalClass.Reptile:
                        animal = new Reptile()
                        {
                            Id = animalsCount + 1,
                            Name = animalDto.Name,
                            Sex = animalDto.Sex,
                            Rank = animalDto.Rank,
                            CoverColor = animalDto.CoverColor,
                            Sound = animalDto.Sound
                        };
                        break;
                    case AnimalClass.Amphibia:
                        animal = new Amphibia()
                        {
                            Id = animalsCount + 1,
                            Name = animalDto.Name,
                            Sex = animalDto.Sex,
                            Rank = animalDto.Rank,
                            CoverColor = animalDto.CoverColor,
                            Sound = animalDto.Sound
                        };
                        break;
                }
            }
            if (animal != null)
            {
                var allAnimals = _repository.GetAll();
                if (!allAnimals.Any(x => StringComparer.CurrentCultureIgnoreCase.Compare(x.Name, animal.Name) == 0))
                {
                    _repository.Add(animal);
                }
            }
        }

        public void Update(string classOfAnimal, AnimalDto animalDto)
        {
            AnimalClass animalClassType;
            Animal oldAnimal = Get(animalDto.Id);
            Animal? animal = null;
            if (oldAnimal.AnimalClass != classOfAnimal)
            {
                if (Enum.TryParse<AnimalClass>(classOfAnimal, out animalClassType))
                {
                    switch (animalClassType)
                    {
                        case AnimalClass.Mammal:
                            animal = new Mammal()
                            {
                                Id = oldAnimal.Id,
                                Name = animalDto.Name,
                                Sex = animalDto.Sex,
                                Rank = animalDto.Rank,
                                CoverColor = animalDto.CoverColor,
                                Sound = animalDto.Sound
                            };
                            break;
                        case AnimalClass.Reptile:
                            animal = new Reptile()
                            {
                                Id = oldAnimal.Id,
                                Name = animalDto.Name,
                                Sex = animalDto.Sex,
                                Rank = animalDto.Rank,
                                CoverColor = animalDto.CoverColor,
                                Sound = animalDto.Sound
                            };
                            break;
                        case AnimalClass.Amphibia:
                            animal = new Amphibia()
                            {
                                Id = oldAnimal.Id,
                                Name = animalDto.Name,
                                Sex = animalDto.Sex,
                                Rank = animalDto.Rank,
                                CoverColor = animalDto.CoverColor,
                                Sound = animalDto.Sound
                            };
                            break;
                    }
                }
            }
            if (animal == null)
            {
                animal = oldAnimal;
                animal.Id = oldAnimal.Id;
                animal.Name = animalDto.Name!;
                animal.Sex = animalDto.Sex!;
                animal.Rank = animalDto.Rank!;
                animal.CoverColor = animalDto.CoverColor!;
                animal.Sound = animalDto.Sound!;
            }
            _repository.Update(animal);
        }
    }
}
