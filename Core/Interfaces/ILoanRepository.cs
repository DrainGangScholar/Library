using api.Core.Entities;

namespace api.Core.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> AddAsync(Loan loan);
    }
}
