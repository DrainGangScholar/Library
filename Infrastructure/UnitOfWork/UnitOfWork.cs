using api.Core.Interfaces;
using api.Infrastructure.Data;

namespace api.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context,
            IUserRepository userRepository,
            IBookRepository bookRepository,
            ILoanRepository loanRepository)
        {
            _context = context;
            Users = userRepository;
            Books = bookRepository;
            Loans = loanRepository;
        }

        public IUserRepository Users { get; }

        public IBookRepository Books { get; }

        public ILoanRepository Loans { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
