using BookStore.DAL.Repositories.BookRepository;

namespace BookStore.DAL.UOW;

public interface IUnitOfWork
{
    IBookRepo BookRepository { get; }   

    Task BeginTransactionAsync();
    Task<int> SaveChangesAsync();
    Task EndTransactionAsync(); // commit
    Task RollbackAsync();
    Task Dispose();
}
