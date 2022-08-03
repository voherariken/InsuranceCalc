using InsuranceCalc.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Repositories.IRepositories
{
    public interface IInsuranceRepository
    {
        List<Occupation> GetOccupationList();
        List<RatingFactor> GetRatingFactors();
    }
}
