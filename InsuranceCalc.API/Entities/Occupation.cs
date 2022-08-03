using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Entities
{
    public class Occupation
    {
        public int OccupationId { get; set; }
        public string OccupationName { get; set; }
        public int RatingFactorId { get; set; }
    }
}
