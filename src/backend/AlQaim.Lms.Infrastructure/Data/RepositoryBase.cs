using AlQaim.Lms.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlQaim.Lms.Infrastructure.Data;
public abstract class RepositoryBase<T> : IRepositoryBase<T>  where T : class
{
    private readonly DbContext _dbContext;

    public RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    #region async
    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Set<T>().Add(entity);
        await SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
       _dbContext.Set<T>().AddRange(entities);
       await SaveChangesAsync(cancellationToken);
       return entities;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Set<T>().Update(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
       _dbContext.Set<T>().UpdateRange(entities);
       await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
    {
        _dbContext.Set<T>().Remove(entity);
        await SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
    {
       _dbContext.Set<T>().RemoveRange(entities);
       await SaveChangesAsync(cancellationToken);
    }

    private async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default(CancellationToken)) where TId : notnull
    {
        return await _dbContext.Set<T>().FindAsync(new object[1] { id }, cancellationToken);
    }


    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
       return await EntityFrameworkQueryableExtensions.CountAsync(_dbContext.Set<T>(), cancellationToken);
    }

    public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
       return await EntityFrameworkQueryableExtensions.AnyAsync(_dbContext.Set<T>(), cancellationToken);
    }

    public Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression) => throw new NotImplementedException();
    public async Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
       return await _dbContext.Set<T>().FindAsync(new object[1] { id }, cancellationToken);
    }
    #endregion
}

