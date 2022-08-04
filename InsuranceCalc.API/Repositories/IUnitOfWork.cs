using InsuranceCalc.API.Repositories.IRepositories;

namespace InsuranceCalc.API.Repositories
{
    public interface IUnitOfWork
    {
        IInsuranceRepository InsuranceRepository { get; }
    }
}
