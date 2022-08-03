using InsuranceCalc.API.Entities;
using InsuranceCalc.API.Repositories;
using InsuranceCalc.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Services
{
    public class InsuranceService : IInsuranceService
    {
        public readonly IUnitOfWork _unitOfWork;
        public InsuranceService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public List<Occupation> GetAllOccupations()
        {
            return this._unitOfWork.InsuranceRepository.GetOccupationList();
        }

        public double CalculateDeathPremium(double deathSumInsured, int occupationId, int age)
        {
            var occupationRatingFactor = this.GetOccupationRatingFactor(occupationId);
            return (deathSumInsured * occupationRatingFactor * age * 12) / 1000;
        }

        private double GetOccupationRatingFactor(int occupationId)
        {
            var ratigFactorId = this._unitOfWork.InsuranceRepository.GetOccupationList().FirstOrDefault(p => p.OccupationId == occupationId).RatingFactorId;
            return this._unitOfWork.InsuranceRepository.GetRatingFactors().FirstOrDefault(p => p.RatingFactorId == ratigFactorId).Factor;
        }
    }
}
