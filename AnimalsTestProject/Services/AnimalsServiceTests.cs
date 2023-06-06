using AnimalsOnPages.Dtos;
using AnimalsOnPages.Interfaces;
using AnimalsOnPages.Models;
using AnimalsOnPages.Services;
using FakeItEasy;
using Shouldly;

namespace AnimalsTestProject.Services
{
    [TestClass]
    public class AnimalsServiceTests
    {
        private AnimalsService? animalsService;
        private IAnimalsRepository? animalsRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            animalsRepository = A.Fake<IAnimalsRepository>();
            animalsService = new AnimalsService(animalsRepository);
        }

        [TestMethod]
        public void Test_GetAll()
        {
            //Arrange
            string firstName = "Dog";
            string secondName = "Lizard";
            string thirdName = "SomeAmphibia";
            var listAnimals = new List<Animal>
            {
                new Mammal()
                {
                    Id = 1,
                    Name = firstName,
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "White",
                    Sound = "Gav, gav, gav"
                },
                new Reptile()
                {
                    Id = 2,
                    Name = secondName,
                    Sex = "Female",
                    Rank = "Hybrids",
                    CoverColor = "LightBrown",
                    Sound = "Sh-sh-sh"
                },
                new Amphibia()
                {
                    Id = 3,
                    Name = thirdName,
                    Sex = "Male",
                    Rank = "Herbivorous",
                    CoverColor = "WhiteGreen",
                    Sound = "Be, be, be"
                }
            };
            A.CallTo(() => animalsRepository.GetAll()).Returns(listAnimals);

            //Act
            var result = animalsService.GetAll();

            //Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(3);
            result[0].Name.ShouldBe(firstName);
            result[2].Name.ShouldBe(thirdName);
            result[0].Rank.ShouldBe(Rank.Carnivorous.ToString());
            result[1].Sex.ShouldBe(Sex.Female.ToString());
            result[2].AnimalClass.ShouldBe(AnimalClass.Amphibia.ToString());
        }

        [TestMethod]
        [DataRow(1, "Dog", "Mammal", true)]
        [DataRow(2, "Lizard", "Reptile", true)]
        [DataRow(1, "Dog", "Reptile", false)]
        [DataRow(2, "Dog", "Reptile", false)]
        [DataRow(3, "SomeAmphibia", "Mammal", false)]
        [DataRow(3, "Lizard", "Amphibia", false)]
        [DataRow(3, "SomeAmphibia", "Amphibia", true)]
        [DataRow(4, "SomeAmphibia", "Amphibia", false)]
        [DataRow(0, "SomeAmphibia", "Amphibia", false)]
        public void Test_Get(int id, string name, string animalClass, bool expectedResult)
        {
            //Arrange
            var listAnimals = new List<Animal>
            {
                new Mammal()
                {
                    Id = 1,
                    Name = "Dog",
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "White",
                    Sound = "Gav, gav, gav"
                },
                new Reptile()
                {
                    Id = 2,
                    Name = "Lizard",
                    Sex = "Female",
                    Rank = "Hybrids",
                    CoverColor = "LightBrown",
                    Sound = "Sh-sh-sh"
                },
                new Amphibia()
                {
                    Id = 3,
                    Name = "SomeAmphibia",
                    Sex = "Male",
                    Rank = "Herbivorous",
                    CoverColor = "WhiteGreen",
                    Sound = "Be, be, be"
                }
            };
            A.CallTo(() => animalsRepository.GetAll()).Returns(listAnimals);
            A.CallTo(() => animalsRepository.Get(id)).Returns(id > 0 && id <= listAnimals.Count ? listAnimals[id - 1] : null);

            //Act
            Animal? animal = animalsService.Get(id);
            var result = animal != null && animal.Name == name && animal.AnimalClass == animalClass;

            //Assert
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow("Mammal", "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Gray", true)]
        [DataRow("Mammal", "Dog", "Female", "Carnivorous", "Gav, gav, gav", "Gray", false)]
        [DataRow("Reptile", "lizard", "Male", "Hybrids", "Sh-sh-sh", "Rainbow", false)]
        [DataRow("Bird", "Craw", "Male", "Hybrids", "Kra, kra, kra", "Black", false)]
        [DataRow("Mammal", "", "Male", "Hybrids", "Woo-oo-oo", "Gray", false)]
        [DataRow("Mammal", "Ra", "Male", "Hybrids", "Woo-oo-oo", "Gray", false)]
        [DataRow("Mammal", "Katopuma Kallimantand", "Male", "Carnivorous", "Gr-r-r", "Gray", false)]
        [DataRow("Mammal", "Wolf", "Male", "Carnivorous", "", "Gray", false)]
        [DataRow("Mammal", "Wolf", "Male", "Carnivorous", "Woo-oo", "Gray", false)]
        [DataRow("Mammal", "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "", true)]
        [DataRow("Mammal", "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Ya", false)]
        [DataRow("Mammal", "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "MediumGoldenrodYellow", false)]
        [DataRow("", "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Gray", false)]
        [DataRow("Mammal", "Wolf", "", "Carnivorous", "Woo-oo-oo", "Gray", true)]
        [DataRow("Mammal", "Wolf", "Male", "", "Woo-oo-oo", "Gray", true)]
        public void Test_Add(string animalClass, string name, string sex, string rank, string sound, string color, bool expectedResult)
        {
            //Arrange
            var listAnimals = new List<Animal>
            {
                new Mammal()
                {
                    Id = 1,
                    Name = "Dog",
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "White",
                    Sound = "Gav, gav, gav"
                },
                new Reptile()
                {
                    Id = 2,
                    Name = "Lizard",
                    Sex = "Female",
                    Rank = "Hybrids",
                    CoverColor = "LightBrown",
                    Sound = "Sh-sh-sh"
                },
                new Amphibia()
                {
                    Id = 3,
                    Name = "SomeAmphibia",
                    Sex = "Male",
                    Rank = "Herbivorous",
                    CoverColor = "WhiteGreen",
                    Sound = "Be, be, be"
                }
            };
            A.CallTo(() => animalsRepository.GetAll()).Returns(listAnimals);

            //Act
            AnimalDto animal = new AnimalDto()
            {
                Id = 0,
                Name = name,
                Sex = sex,
                Rank = rank,
                Sound = sound,
                CoverColor = color
            };
            animalsService.Add(animalClass, animal);
            var result = Fake.GetCalls(animalsRepository).Any(call => call.Method.Name == "Add");

            //Assert
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow("Mammal", 1, "Wolf", "Male", "Carnivorous", "Gav, gav, gav", "White", true)]
        [DataRow("Mammal", 4, "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Gray", false)]
        [DataRow("Mammal", 0, "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Gray", false)]
        [DataRow("Mammal", 1, "Dog", "Male", "Carnivorous", "Woo-oo-oo", "Gray", true)]
        [DataRow("Reptile", 1, "Snake", "Female", "Hybrids", "Sh-sh-sh", "Orange", true)]
        [DataRow("Bird", 1, "Craw", "Female", "Hybrids", "Kra, kra, kra", "Black", false)]
        [DataRow("Mammal", 1, "", "Male", "Carnivorous", "Gav, gav, gav", "White", false)]
        [DataRow("Mammal", 1, "Ra", "Male", "Carnivorous", "Gav, gav, gav", "White", false)]
        [DataRow("Mammal", 1, "Katopuma Kallimantand", "Male", "Carnivorous", "Gr-r-r", "White", false)]
        [DataRow("Mammal", 1, "Wolf", "Male", "Carnivorous", "", "Gray", false)]
        [DataRow("Mammal", 1, "Wolf", "Male", "Carnivorous", "Woo-oo", "Gray", false)]
        [DataRow("Mammal", 1, "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "", true)]
        [DataRow("Mammal", 1, "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Ya", false)]
        [DataRow("Mammal", 1, "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "MediumGoldenrodYellow", false)]
        [DataRow("", 1, "Wolf", "Male", "Carnivorous", "Woo-oo-oo", "Gray", false)]
        [DataRow("Mammal", 1, "Wolf", "", "Carnivorous", "Woo-oo-oo", "Gray", true)]
        [DataRow("Mammal", 1, "Wolf", "Male", "", "Woo-oo-oo", "Gray", true)]
        public void Test_Update(string animalClass, int id, string name, string sex, string rank, string sound, string color, bool expectedResult)
        {
            //Arrange
            var listAnimals = new List<Animal>
            {
                new Mammal()
                {
                    Id = 1,
                    Name = "Dog",
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "White",
                    Sound = "Gav, gav, gav"
                },
                new Reptile()
                {
                    Id = 2,
                    Name = "Lizard",
                    Sex = "Female",
                    Rank = "Hybrids",
                    CoverColor = "LightBrown",
                    Sound = "Sh-sh-sh"
                },
                new Amphibia()
                {
                    Id = 3,
                    Name = "SomeAmphibia",
                    Sex = "Male",
                    Rank = "Herbivorous",
                    CoverColor = "WhiteGreen",
                    Sound = "Be, be, be"
                }
            };
            A.CallTo(() => animalsRepository.GetAll()).Returns(listAnimals);
            A.CallTo(() => animalsRepository.Get(id)).Returns(id > 0 && id <= listAnimals.Count ? listAnimals[id - 1] : null);

            //Act
            AnimalDto animal = new AnimalDto()
            {
                Id = id,
                Name = name,
                Sex = sex,
                Rank = rank,
                Sound = sound,
                CoverColor = color
            };
            animalsService.Update(animalClass, animal);
            var result = Fake.GetCalls(animalsRepository).Any(call => call.Method.Name == "Update");

            //Assert
            result.ShouldBe(expectedResult);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(4, false)]
        [DataRow(0, false)]
        public void Test_Delete(int id, bool expectedResult)
        {
            //Arrange
            var listAnimals = new List<Animal>
            {
                new Mammal()
                {
                    Id = 1,
                    Name = "Dog",
                    Sex = "Male",
                    Rank = "Carnivorous",
                    CoverColor = "White",
                    Sound = "Gav, gav, gav"
                },
                new Reptile()
                {
                    Id = 2,
                    Name = "Lizard",
                    Sex = "Female",
                    Rank = "Hybrids",
                    CoverColor = "LightBrown",
                    Sound = "Sh-sh-sh"
                },
                new Amphibia()
                {
                    Id = 3,
                    Name = "SomeAmphibia",
                    Sex = "Male",
                    Rank = "Herbivorous",
                    CoverColor = "WhiteGreen",
                    Sound = "Be, be, be"
                }
            };
            A.CallTo(() => animalsRepository.GetAll()).Returns(listAnimals);

            //Act
            animalsService.Delete(id);
            var result = Fake.GetCalls(animalsRepository).Any(call => call.Method.Name == "Delete");

            //Assert
            result.ShouldBe(expectedResult);
        }
    }
}
