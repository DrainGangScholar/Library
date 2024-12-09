using api.Core.DTOs;
using api.Core.Entities;
using api.Core.Interfaces;
using api.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Services
{
    class LoanService : ILoanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoanDTO?> CreateLoan(CreateLoanDTO request)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {request.UserId} not found!");
            }
            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId);
            if (book == null)
            {
                throw new InvalidOperationException($"Book with id {request.BookId} not found!");
            }
            if (book.LoanId != null)
            {
                throw new InvalidOperationException($"Book with id {request.BookId} is already borrowed!");
            }
            var loan = Loan.From(request, user, book);
            Loan? createdLoan = await _unitOfWork.Loans.AddAsync(loan);

            book.LoanId = loan.Id;
            _unitOfWork.Books.Update(book);

            await _unitOfWork.SaveChangesAsync();
            return LoanDTO.From(loan);
        }

        public async Task FinishLoan(Guid id)
        {
            var loan = await _unitOfWork.Loans.GetByIdWithIncludesAsync(id, l => l.Book, l => l.User);
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
            _unitOfWork.Books.Update(book);
            _unitOfWork.Loans.Update(loan);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<LoanDTO>> GetAllLoans(bool? returned)
        {
            var loans = await _unitOfWork.Loans.GetAll(returned);
            return loans.Select(l => LoanDTO.From(l)).ToList();
        }
    }
}

