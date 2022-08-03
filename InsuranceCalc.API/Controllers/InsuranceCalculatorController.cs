using InsuranceCalc.API.Entities;
using InsuranceCalc.API.Models;
using InsuranceCalc.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace InsuranceCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCalculatorController : ControllerBase
    {
        private readonly ILogger<InsuranceCalculatorController> _logger;
        private readonly IInsuranceService _insuranceService;
        public InsuranceCalculatorController(ILogger<InsuranceCalculatorController> logger, IInsuranceService insuranceService)
        {
            this._logger = logger;
            this._insuranceService = insuranceService;
        }

        [Route("occupations")]
        [HttpGet]
        public IEnumerable<Occupation> GetOccupations()
        {
            return this._insuranceService.GetAllOccupations();
        }

        [Route("deathPremium")]
        [HttpPost]
        public IActionResult GetDeathPremium(InsuranceCalcModel insuranceCalcModel)
        {
            try
            {
                if (!ModelState.IsValid || !this.ValidateInsuranceCalcModel(insuranceCalcModel))
                {
                    return BadRequest();
                }
                
                var deathPremium = this._insuranceService.CalculateDeathPremium(insuranceCalcModel.DeathSumInsured, insuranceCalcModel.OccupationId, insuranceCalcModel.Age);
                return Ok(deathPremium);
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        private bool ValidateInsuranceCalcModel(InsuranceCalcModel insuranceCalcModel)
        {
            if (insuranceCalcModel.DateOfBirth > DateTime.Now || insuranceCalcModel.DateOfBirth.Year < 1900)
            {
                return false;
            }
            return true;
        }
    }
}
