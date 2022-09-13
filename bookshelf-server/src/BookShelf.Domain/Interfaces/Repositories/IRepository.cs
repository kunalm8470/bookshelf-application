using System.Linq.Expressions;

namespace BookShelf.Domain.Interfaces.Repositories;

public interface IRepository<TEnt, TKey> where TEnt : class where TKey : struct
{
    Task<IReadOnlyList<TEnt>> ListAsync(Expression<Func<TEnt, bool>> predicate, int skip, int limit, CancellationToken cancellationToken = default);
    Task<TEnt> FirstOrDefaultAsync(Expression<Func<TEnt, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEnt> FindByPrimaryKeyAsync(TKey id, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<int> CountAsync(Expression<Func<TEnt, bool>> predicate, CancellationToken cancellationToken = default);
    Task<TEnt> AddAsync(TEnt entity, CancellationToken cancellationToken = default);
    Task<TEnt> UpdateAsync(TEnt entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEnt entity, CancellationToken cancellationToken = default);
}
