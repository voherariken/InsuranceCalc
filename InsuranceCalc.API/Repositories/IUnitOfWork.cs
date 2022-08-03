using InsuranceCalc.API.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCalc.API.Repositories
{
    public interface IUnitOfWork
    {
        IInsuranceRepository InsuranceRepository { get; }
    }
}
