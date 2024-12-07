namespace api.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBookRepository Books { get; }
        ILoanRepository Loans { get; }
        Task<int> SaveChangesAsync();
    }
}
