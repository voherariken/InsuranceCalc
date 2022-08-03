using InsuranceCalc.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Repositories
{
    public class InsuranceDbContext
    {
        //using static data temporarily until we link it with DB
        private static List<Occupation> occupations = new List<Occupation>()
        {
            new Occupation{ OccupationId = 1, OccupationName = "Cleaner", RatingFactorId = 3 },
            new Occupation{ OccupationId = 2, OccupationName = "Doctor", RatingFactorId = 1 },
            new Occupation{ OccupationId = 3, OccupationName = "Author", RatingFactorId = 2 },
            new Occupation{ OccupationId = 4, OccupationName = "Farmer", RatingFactorId = 4 },
            new Occupation{ OccupationId = 5, OccupationName = "Mechanic", RatingFactorId = 4 },
            new Occupation{ OccupationId = 5, OccupationName = "Florist", RatingFactorId = 3 }
        };

        private static List<RatingFactor> ratingFactors = new List<RatingFactor>()
        {
            new RatingFactor{ RatingFactorId = 1, RatingFactorName = "Professional", Factor = 1.00 },
            new RatingFactor{ RatingFactorId = 2, RatingFactorName = "White Collar", Factor = 1.25 },
            new RatingFactor{ RatingFactorId = 3, RatingFactorName = "Light Manual", Factor = 1.50 },
            new RatingFactor{ RatingFactorId = 4, RatingFactorName = "Heavy Manual", Factor = 1.75 },
        };

        public List<Occupation> Occupations { get => InsuranceDbContext.occupations; }
        public List<RatingFactor> RatingFactors { get => InsuranceDbContext.ratingFactors; }
    }
}
