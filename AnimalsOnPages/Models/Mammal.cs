﻿using AnimalsOnPages.Utilities;
using System.ComponentModel.DataAnnotations;

namespace AnimalsOnPages.Models
{
    public class Mammal : Animal
    {
        public override int Id { get; set; }

        [Required]
        public override string Name { get; set; }

        public override string Sex
        {
            get { return sex.GetDescription(); }
            set
            {
                Sex sexType;
                if (Enum.TryParse<Sex>(value, out sexType))
                {
                    switch (sexType)
                    {
                        case Models.Sex.Male:
                            sex = Models.Sex.Male;
                            break;
                        case Models.Sex.Female:
                            sex = Models.Sex.Female;
                            break;
                    }
                }
            }
        }

        public override string Rank
        {
            get { return rank.GetDescription(); }
            set
            {
                Rank rankType;
                if (Enum.TryParse<Rank>(value, out rankType))
                {
                    switch (rankType)
                    {
                        case Models.Rank.Carnivorous:
                            rank = Models.Rank.Carnivorous;
                            break;
                        case Models.Rank.Herbivorous:
                            rank = Models.Rank.Herbivorous;
                            break;
                        case Models.Rank.Hybrids:
                            rank = Models.Rank.Hybrids;
                            break;
                    }
                }
            }
        }

        [Required]
        public override string Sound { get; set; }

        public override string? CoverColor { get; set; }

        private readonly string animalClass = "Mammal";
        private readonly string birth = "Live birth";
        private readonly string bodyTemperature = "Hematothermal";
        private readonly string bodyCovering = "Hair";
        private Sex sex;
        private Rank rank;

        public override string AnimalClass { get { return Resources.Resource.Animals_MammalClass; } }
        public override string Birth { get { return Resources.Resource.Mammal_Birth; } }
        public override string BodyTemperature { get { return Resources.Resource.Mammal_Temperature; } }
        public override string BodyCovering { get { return Resources.Resource.Mammal_Covering; } }

        public override ICollection<Zoo>? Zoos { get; set; }
    }
}
