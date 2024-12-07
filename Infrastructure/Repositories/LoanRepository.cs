using api.Core.Entities;
using api.Core.Interfaces;
using api.Infrastructure.Data;

namespace api.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DataContext _context;

        public LoanRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Loan?> AddAsync(Loan loan)
        {
            var createdLoan = await _context.Loans.AddAsync(loan);
            return createdLoan.Entity;
        }
    }
}
