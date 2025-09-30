using GoldenBanana.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace GoldenBanana.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync()
    {
        if (_transaction != null) return;
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction == null) return;

        await _transaction.CommitAsync();
        await _context.SaveChangesAsync();
        await _transaction.DisposeAsync();

        _transaction = null;
    }

    public async Task RollbackAsync()
    {
        if (_transaction == null) return;

        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();

        _transaction = null;
    }
}
