using InsuranceCalc.API.Entities;
using InsuranceCalc.API.Repositories;
using InsuranceCalc.API.Services;
using InsuranceCalc.API.Services.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InsuranceCalc.Test.ServicesTest
{
    public class InsuranceServiceTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private IInsuranceService _iInsuranceService;

        private List<Occupation> occupations;

        private List<RatingFactor> ratingFactors;

        public InsuranceServiceTest()
        {
            this._unitOfWork = new Mock<IUnitOfWork>();
            this._iInsuranceService = new InsuranceService(this._unitOfWork.Object);

            this.occupations = new List<Occupation>()
            {
                new Occupation{ OccupationId = 1, OccupationName = "Cleaner", RatingFactorId = 3 },
                new Occupation{ OccupationId = 2, OccupationName = "Doctor", RatingFactorId = 1 },
                new Occupation{ OccupationId = 3, OccupationName = "Author", RatingFactorId = 2 },
                new Occupation{ OccupationId = 4, OccupationName = "Farmer", RatingFactorId = 4 }
            };
            this.ratingFactors = new List<RatingFactor>()
            {
                new RatingFactor{ RatingFactorId = 1, RatingFactorName = "Professional", Factor = 1.00 },
                new RatingFactor{ RatingFactorId = 2, RatingFactorName = "White Collar", Factor = 1.25 },
                new RatingFactor{ RatingFactorId = 3, RatingFactorName = "Light Manual", Factor = 1.50 },
                new RatingFactor{ RatingFactorId = 4, RatingFactorName = "Heavy Manual", Factor = 1.75 },
            };
        }

        [Theory]
        [InlineData(100000, 1, 25, 45000)]
        public void TestCalculateDeathPremium(double deathSumInsured, int occupationId, int age, int expectedResult)
        {
            //Arrange
            this._unitOfWork.Setup(p => p.InsuranceRepository.GetOccupationList()).Returns(this.occupations);
            this._unitOfWork.Setup(p => p.InsuranceRepository.GetRatingFactors()).Returns(this.ratingFactors);

            //Act
            var actualResult = this._iInsuranceService.CalculateDeathPremium(deathSumInsured, occupationId, age);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
