﻿using System.Linq.Expressions;

namespace Demo.Revition.DataAccess.IRepositories;

public interface IRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> CreateAsync(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
    ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression,
        string[] includes = null);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null,
        bool isTracking = false,
        string[] includes = null);
    ValueTask<bool> SaveAsync();
}