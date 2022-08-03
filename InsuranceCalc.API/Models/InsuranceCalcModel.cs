using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Models
{
    public class InsuranceCalcModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage ="Age cannot be negative")]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int OccupationId { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "DeathSumInsured cannot be negative")]
        public double DeathSumInsured { get; set; }

    }
}
