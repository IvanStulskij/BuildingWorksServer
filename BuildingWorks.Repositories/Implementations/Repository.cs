using BuildingWorks.Common;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BuildingWorks.Repositories.Implementations;

public class Repository<T> : IRepository<T>
    where T : Entity
{
    protected BuildingWorksDbContext Context { get; init; }
    protected DbSet<T> Set { get; init; }

    public Repository(BuildingWorksDbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public virtual async Task Delete(Guid id)
    {
        var deletedCount = await Set.Where(entity => entity.Id == id)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Entity of type {typeof(T).Name} with id {id} doesn't exist in database");
        }
    }

    public virtual IQueryable<T> Get()
    {
        var entitiesByPage = Set.AsNoTracking();

        return entitiesByPage;
    }

    public virtual async Task<T> GetById(Guid id)
    {
        var entity = await Set.AsNoTracking().SingleOrDefaultAsync(item => item.Id == id);

        if (entity == null)
        {
            throw new EntityNotExistException($"Entity of type {typeof(T).Name} with id {id} not exist in database");
        }

        return entity;
    }

    public virtual async Task<T> Insert(T entity)
    {
        var added = await Set.AddAsync(entity);
        await Context.SaveChangesAsync();

        return added.Entity;
    }

    public virtual async Task Insert(IEnumerable<T> entities)
    {
        await Set.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public virtual async Task<T> Update(T entity)
    {
        var updated = Set.Update(entity);
        await Context.SaveChangesAsync();

        return updated.Entity;
    }

    public virtual IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
    {
        return Set.AsNoTracking().Where(condition);
    }
}
