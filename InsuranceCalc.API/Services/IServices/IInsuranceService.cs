using InsuranceCalc.API.Models;
using System.Collections.Generic;

namespace InsuranceCalc.API.Services.IServices
{
    public interface IInsuranceService
    {
        List<OccupationModel> GetAllOccupations();
        double CalculateDeathPremium(double deathSumInsured, int occupationId, int age);
    }
}
