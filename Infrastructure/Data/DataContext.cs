using api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Book>()
                .HasOne(b=>b.Loan)
                .WithOne(l=>l.Book)
                .HasForeignKey("Book","LoanId");
        }
    }
}
