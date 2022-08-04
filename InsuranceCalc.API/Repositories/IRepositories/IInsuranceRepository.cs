using InsuranceCalc.API.Entities;
using System.Collections.Generic;

namespace InsuranceCalc.API.Repositories.IRepositories
{
    public interface IInsuranceRepository
    {
        List<Occupation> GetOccupationList();
        List<RatingFactor> GetRatingFactors();
    }
}
