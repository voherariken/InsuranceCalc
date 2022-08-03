using InsuranceCalc.API.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
