using InsuranceCalc.API.Entities;
using InsuranceCalc.API.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
