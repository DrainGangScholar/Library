using api.Core.DTOs;

namespace api.Core.Services
{
    public interface ILoanService
    {
        public Task<LoanDTO?> CreateLoan(CreateLoanDTO request);
        public Task<List<LoanDTO>> GetAllLoans(bool? returned);
        public Task FinishLoan(Guid id);
    }
}
