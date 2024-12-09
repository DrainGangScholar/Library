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

        public async Task<List<Loan>> GetAll(bool? returned)
        {
            var loansQuery = _context.Loans.Include(l => l.Book).Include(l => l.User).AsQueryable();

            if (returned != null)
            {
                loansQuery = loansQuery.Where(l => l.IsReturned == returned);
            }
            return await loansQuery.ToListAsync();
        }
    }
}
