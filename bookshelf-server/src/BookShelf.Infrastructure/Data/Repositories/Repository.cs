using BookShelf.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShelf.Infrastructure.Data.Repositories;

public abstract class Repository<TEnt, TKey> : IRepository<TEnt, TKey> where TEnt : class where TKey : struct
{
    private readonly BookshelfDbContext _dbContext;

    public Repository(BookshelfDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEnt> AddAsync(TEnt entity, CancellationToken cancellationToken = default)
    {
        var entry = await _dbContext.Set<TEnt>().AddAsync(entity, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEnt>().CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEnt, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<TEnt> query = _dbContext.Set<TEnt>();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query.CountAsync(cancellationToken);
    }

    public async Task DeleteAsync(TEnt entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEnt>().Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEnt> FindByPrimaryKeyAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.FindAsync<TEnt>(id);
    }

    public async Task<TEnt> FirstOrDefaultAsync(Expression<Func<TEnt, bool>> predicate, CancellationToken cancellationToken = default)
    {
        IQueryable<TEnt> query = _dbContext.Set<TEnt>();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEnt>> ListAsync(Expression<Func<TEnt, bool>> predicate, int skip, int limit, CancellationToken cancellationToken = default)
    {
        IQueryable<TEnt> query = _dbContext.Set<TEnt>();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query
            .Skip(skip)
            .Take(limit)
            .ToListAsync(cancellationToken);
    }

    public async Task<TEnt> UpdateAsync(TEnt entity, CancellationToken cancellationToken = default)
    {
        var entry = _dbContext.Set<TEnt>().Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }
}
