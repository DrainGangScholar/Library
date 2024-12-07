using api.Core.DTOs;
using api.Core.Entities;
using api.Core.Services;
using api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Services
{
    class LoanService : ILoanService
    {
        private readonly DataContext _context;

        public LoanService(DataContext context)
        {
            _context = context;
        }

        public async Task<LoanDTO?> CreateLoan(CreateLoanDTO request)
        {
            var user = await _context.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {request.UserId} not found!");
            }
            var book = await _context.Books.Where(b => b.Id == request.BookId).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new InvalidOperationException($"Book with id {request.BookId} not found!");
            }
            if (book.LoanId != null)
            {
                throw new InvalidOperationException($"Book with id {request.BookId} is already borrowed!");
            }
            var loan = Loan.From(request, user, book);
            _context.Loans.Add(loan);

            book.LoanId = loan.Id;
            _context.Books.Update(book);

            await _context.SaveChangesAsync();
            return LoanDTO.From(loan);
        }

        public async Task FinishLoan(Guid id)
        {
            var loan = await _context.Loans.Where(l => l.Id == id).Include(l => l.Book).Include(l => l.User).FirstOrDefaultAsync();
            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with id {id} not found!");
            }
            if (loan.IsReturned)
            {
                return;
            }
            loan.IsReturned = true;
            loan.ReturnedDate = DateTime.Today;
            if (loan.Book == null)
            {
                throw new InvalidOperationException($"The loan with id {id} does not have an associated book.");
            }
            var book = loan.Book;
            book.LoanId = null;
            _context.Books.Update(book);
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LoanDTO>> GetAllLoans(bool? returned)
        {
            var loansQuery = _context.Loans.Include(l => l.Book).Include(l => l.User).AsQueryable();
            if (returned != null)
            {
                loansQuery = loansQuery.Where(l => l.IsReturned == returned);
            }
            var loans = await loansQuery.ToListAsync();
            if (loans == null)
            {
                return LoanDTO.EmptyList();
            }
            return loans.Select(l => LoanDTO.From(l)).ToList();
        }
    }
}

