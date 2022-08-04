using InsuranceCalc.API.Controllers;
using InsuranceCalc.API.Models;
using InsuranceCalc.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InsuranceCalc.Test.ControllersTest
{
    public class InsuranceCalculatorControllerTest
    {
        private readonly InsuranceCalculatorController _insuranceCalculatorController; 
        private readonly Mock<ILogger<InsuranceCalculatorController>> _logger;
        private readonly Mock<IInsuranceService> _insuranceService;
        private readonly List<OccupationModel> occupations;
        public InsuranceCalculatorControllerTest()
        {
            this._logger = new Mock<ILogger<InsuranceCalculatorController>>();
            this._insuranceService = new Mock<IInsuranceService>();
            this._insuranceCalculatorController = new InsuranceCalculatorController(this._logger.Object, this._insuranceService.Object);

            this.occupations = new List<OccupationModel>()
            {
                new OccupationModel{ OccupationId = 1, OccupationName = "Cleaner"},
                new OccupationModel{ OccupationId = 2, OccupationName = "Doctor"},
                new OccupationModel{ OccupationId = 3, OccupationName = "Author"},
                new OccupationModel{ OccupationId = 4, OccupationName = "Farmer"}
            };
        }

        [Fact]
        public void TestGetOccupations()
        {
            //Arrange
            this._insuranceService.Setup(p => p.GetAllOccupations()).Returns(this.occupations);

            //Act
            var actualResult = this._insuranceCalculatorController.GetOccupations();

            //Assert
            Assert.Equal(this.occupations.Count, ((List<OccupationModel>)actualResult).Count);
        }

        [Theory]
        [MemberData(nameof(insuranceCalcModels))]
        public void TestGetDeathPremium(InsuranceCalcModel insuranceCalcModel, Type type)
        {
            //Arrange
            this._insuranceService.Setup(p => p.CalculateDeathPremium(10000, 1, 25)).Returns(4500);

            //Act
            var actualResult = this._insuranceCalculatorController.GetDeathPremium(insuranceCalcModel);

            //Assert
            Assert.IsType(type, actualResult);
        }

        public static IEnumerable<Object[]> insuranceCalcModels =>
            new List<Object[]>
            {
                new object[]
                { 
                    new InsuranceCalcModel { Name = "Test", Age = 25, DateOfBirth = new DateTime(2050, 1, 1), OccupationId = 1, DeathSumInsured = 10000 }, //future DOB 
                    typeof(BadRequestResult)
                },
                new object[]
                {
                    new InsuranceCalcModel { Name = "Test", Age = 25, DateOfBirth = new DateTime(1850, 1, 1), OccupationId = 1, DeathSumInsured = 10000 }, //DOB before year 1900
                    typeof(BadRequestResult)
                },
                new object[]
                {
                    new InsuranceCalcModel { Name = "Test", Age = 25, DateOfBirth = new DateTime(1950, 1, 1), OccupationId = 1, DeathSumInsured = 10000 }, //All good
                    typeof(OkObjectResult)
                }
            };
    }
}
