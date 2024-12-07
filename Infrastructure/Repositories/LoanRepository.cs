using System.Linq.Expressions;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Loan?> GetByIdWithIncludesAsync(Guid id, params Expression<Func<Loan, object>>[] includes)
        {
            var query = _context.Loans.AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(l => l.Id == id);
        }

        public void Update(Loan loan)
        {
            _context.Update(loan);
        }
    }
}
