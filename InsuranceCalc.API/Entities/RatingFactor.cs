using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Entities
{
    public class RatingFactor
    {
        public int RatingFactorId { get; set; }
        public string RatingFactorName { get; set; }
        public double Factor { get; set; }
    }
}
