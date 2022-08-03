using InsuranceCalc.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Services.IServices
{
    public interface IInsuranceService
    {
        List<Occupation> GetAllOccupations();
        double CalculateDeathPremium(double deathSumInsured, int occupationId, int age);
    }
}
