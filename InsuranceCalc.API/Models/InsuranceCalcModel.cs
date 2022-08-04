using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCalc.API.Models
{
    public class InsuranceCalcModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Age cannot be less than 1")]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int OccupationId { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Death Sum Insured cannot be less than 1")]
        public double DeathSumInsured { get; set; }

    }
}
