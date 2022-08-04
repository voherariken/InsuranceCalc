using InsuranceCalc.API.Entities;
using InsuranceCalc.API.Repositories.IRepositories;
using System.Collections.Generic;

namespace InsuranceCalc.API.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly InsuranceDbContext _insuranceDbContext;
        public InsuranceRepository(InsuranceDbContext insuranceDbContext)
        {
            this._insuranceDbContext = insuranceDbContext;
        }
        public List<Occupation> GetOccupationList()
        {
            return this._insuranceDbContext.Occupations;
        }

        public List<RatingFactor> GetRatingFactors()
        {
            return this._insuranceDbContext.RatingFactors;
        }
    }
}
