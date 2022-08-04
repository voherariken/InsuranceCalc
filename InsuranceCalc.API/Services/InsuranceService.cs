using InsuranceCalc.API.Models;
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

        public List<OccupationModel> GetAllOccupations()
        {
            return this._unitOfWork.InsuranceRepository.GetOccupationList()
                .Select(
                p => new OccupationModel
                {
                    OccupationId = p.OccupationId,
                    OccupationName = p.OccupationName
                })
                .ToList();
        }

        public double CalculateDeathPremium(double deathSumInsured, int occupationId, int age)
        {
            var occupationRatingFactor = this.GetOccupationRatingFactor(occupationId);
            var deathPremium = (deathSumInsured * occupationRatingFactor * age * 12) / 1000;
            return Math.Round(deathPremium, 2);
        }

        private double GetOccupationRatingFactor(int occupationId)
        {
            var ratigFactorId = this._unitOfWork.InsuranceRepository.GetOccupationList().Single(p => p.OccupationId == occupationId).RatingFactorId;
            return this._unitOfWork.InsuranceRepository.GetRatingFactors().Single(p => p.RatingFactorId == ratigFactorId).Factor;
        }
    }
}
