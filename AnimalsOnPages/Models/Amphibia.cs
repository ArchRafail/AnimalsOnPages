﻿using AnimalsOnPages.Utilities;
using System.ComponentModel.DataAnnotations;

namespace AnimalsOnPages.Models
{
    public class Amphibia : Animal
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

        private readonly string animalClass = "Amphibia";
        private readonly string birth = "From egg";
        private readonly string bodyTemperature = "Cold-blooded";
        private readonly string bodyCovering = "Bare skin";
        private Sex sex;
        private Rank rank;

        public override string AnimalClass { get { return Resources.Resource.Animals_AmphibiaClass; } }
        public override string Birth { get { return Resources.Resource.Amphibia_Birth; } }
        public override string BodyTemperature { get { return Resources.Resource.Amphibia_Temperature; } }
        public override string BodyCovering { get { return Resources.Resource.Amphibia_Covering; } }

        public override ICollection<Zoo>? Zoos { get; set; }
    }
}
