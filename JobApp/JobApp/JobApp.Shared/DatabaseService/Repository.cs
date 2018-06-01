using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Threading.Tasks;
using JobApp.Shared.Models;

namespace JobApp.Shared.DatabaseServices
{
    public class Repository<TEntity> where TEntity : BasicObject, new()
    {
        private readonly SQLiteAsyncConnection _database;

        public Repository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<TEntity> TryGetByIdAsync(Guid id)
        {
            try
            {
                return await _database.GetAsync<TEntity>(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<TEntity> TryGetByIdWithChildrenAsync(Guid id)
        {
            try
            {
                var q = await _database.GetWithChildrenAsync<TEntity>(id);
                return q;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<TEntity>> TryGetAllAsync()
        {
            try
            {
                return await _database
                    .Table<TEntity>()
                    .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<TEntity>> TryGetAllWithChildrenAsync()
        {
            try
            {
                return await _database.GetAllWithChildrenAsync<TEntity>();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<TEntity>> TryGetMatchingAsync(Expression<Func<TEntity, bool>> condition)
        {
            try
            {
                return await _database
                    .Table<TEntity>()
                    .Where(condition)
                    .ToListAsync();
            }
            catch
            {
                return null;
            }
        }


        public async Task<bool> TryAddEntityAsync(TEntity entity)
        {
            try
            {
                await _database.InsertAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteEntityAsync(TEntity entity, bool recursive = false)
        {
            try
            {
                await _database.DeleteAsync(entity, recursive);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryUpdateEntityAsync(TEntity entity)
        {
            try
            {
                await _database.UpdateAsync(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TEntity> LoadChildrenOfEntityAsync(TEntity entity, bool recursive = false)
        {
            _database.GetChildrenAsync(entity, recursive).Wait();
            return entity;
        }
    }
}
