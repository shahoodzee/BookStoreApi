using BookStore.DAL.Data;
using BookStore.DAL.Repositories.BookRepository;

using Microsoft.EntityFrameworkCore.Storage;

namespace BookStore.DAL.UOW;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext context;
    private IDbContextTransaction transaction;

    public IBookRepo BookRepository { get;}

    public UnitOfWork(ApplicationDbContext _context, IBookRepo _BookRepository)
    {
        this.context = _context;
        BookRepository = _BookRepository;
    }
    public async Task BeginTransactionAsync()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task EndTransactionAsync()
    {
        try
        {
            //await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackAsync();
        }
    }

    public async Task RollbackAsync()
    {
        await transaction.RollbackAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public async Task Dispose()
    {
        //await context.DisposeAsync();
        throw new NotImplementedException();
    }

}
