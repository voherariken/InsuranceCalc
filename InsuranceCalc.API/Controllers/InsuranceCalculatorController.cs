using InsuranceCalc.API.Entities;
using InsuranceCalc.API.Models;
using InsuranceCalc.API.Services;
using InsuranceCalc.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceCalc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCalculatorController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;
        public InsuranceCalculatorController(IInsuranceService insuranceService)
        {
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(); //see how to send errors too
                }
                //Check other validations i.e. Age is too high, DOB is invalid etc.
                var deathPremium = this._insuranceService.CalculateDeathPremium(insuranceCalcModel.DeathSumInsured, insuranceCalcModel.OccupationId, insuranceCalcModel.Age);
                return Ok(deathPremium);
            }
            catch(Exception ex) //log exception
            {
                return BadRequest();
            }
        }
    }
}
