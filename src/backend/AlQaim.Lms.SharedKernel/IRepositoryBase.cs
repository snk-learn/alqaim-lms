namespace AlQaim.Lms.SharedKernel;
//generate irepositorybase interface
using System.Linq.Expressions;

public interface IRepositoryBase<T> where T : class
{
    #region async
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    
    Task<int> CountAsync(CancellationToken cancellationToken);
    #endregion
}

