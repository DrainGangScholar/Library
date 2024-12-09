using System.Linq.Expressions;
using api.Core.Entities;

namespace api.Core.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> AddAsync(Loan loan);
        Task<Loan?> GetByIdWithIncludesAsync(Guid id, params Expression<Func<Loan, object>>[] includes);
        void Update(Loan loan);
        Task<List<Loan>> GetAll(bool? returned);
    }
}
