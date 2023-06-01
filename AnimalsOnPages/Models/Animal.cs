using AnimalsOnPages.Resources;
using AnimalsOnPages.Utilities;

namespace AnimalsOnPages.Models
{

    public enum AnimalClass
    {
        [LocalizedDescription("Animals_MammalClass", typeof(Resource))]
        Mammal,
        [LocalizedDescription("Animals_ReptileClass", typeof(Resource))]
        Reptile,
        [LocalizedDescription("Animals_AmphibiaClass", typeof(Resource))]
        Amphibia
    }

    public enum Sex
    {
        [LocalizedDescription("Animals_MaleSex", typeof(Resource))]
        Male,
        [LocalizedDescription("Animals_FemaleSex", typeof(Resource))]
        Female
    }

    public enum Rank
    {
        [LocalizedDescription("Animals_CarnivorousRank", typeof(Resource))]
        Carnivorous,
        [LocalizedDescription("Animals_HerbivorousRank", typeof(Resource))]
        Herbivorous,
        [LocalizedDescription("Animals_HybridsRank", typeof(Resource))]
        Hybrids
    }

    public abstract class Animal
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string Sex { get; set; }
        public abstract string Rank { get; set; }
        public abstract string Sound { get; set; }
        public abstract string AnimalClass { get; }
        public abstract string Birth { get; }
        public abstract string BodyTemperature { get; }
        public abstract string BodyCovering { get; }
        public abstract string CoverColor { get; set; }

    }
}
