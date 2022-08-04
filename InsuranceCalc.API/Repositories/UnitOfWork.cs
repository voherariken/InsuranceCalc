using InsuranceCalc.API.Repositories.IRepositories;

namespace InsuranceCalc.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InsuranceDbContext insuranceDbContext;
        private IInsuranceRepository insuranceRepository;
        public UnitOfWork()
        {
            this.insuranceDbContext = new InsuranceDbContext();
        }
        public IInsuranceRepository InsuranceRepository { get
            {
                if (this.insuranceRepository == null)
                {
                    this.insuranceRepository = new InsuranceRepository(this.insuranceDbContext);
                }
                return this.insuranceRepository;
            } 
        }

    }
}
