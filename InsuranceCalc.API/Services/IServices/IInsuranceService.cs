using InsuranceCalc.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Services.IServices
{
    public interface IInsuranceService
    {
        List<OccupationModel> GetAllOccupations();
        double CalculateDeathPremium(double deathSumInsured, int occupationId, int age);
    }
}
