using Demo.Revition.DataAccess.Contexts;
using Demo.Revition.DataAccess.IRepositories;
using Demo.Revition.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Demo.Revition.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        EntityEntry<TEntity> entry = await _dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        EntityEntry<TEntity> entry = _dbContext.Update(entity);

        return entry.Entity;
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Remove(entity);
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
    {
        IQueryable<TEntity> entities = expression == null ? _dbSet.AsQueryable() :
            _dbSet.Where(expression).AsQueryable();

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null,
        bool isTracking = false, string[] includes = null)
    {
        IQueryable<TEntity> entities = expression == null ? _dbSet.AsQueryable()
            : this._dbSet.Where(expression).AsQueryable();

        entities = isTracking ? entities.AsNoTracking() : entities;

        if (includes is not null)
            foreach (var include in includes)
                entities = entities.Include(include);

        return entities;
    }

    public async Task<bool> SaveAsync()
        => await _dbContext.SaveChangesAsync() >= 0;
}