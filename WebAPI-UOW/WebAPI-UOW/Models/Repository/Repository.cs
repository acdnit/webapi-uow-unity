using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI_UOW.Models.Repository {
    public class Repository<T> : IRepository<T> where T : class {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext) {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual int Count => _dbSet.Count();

        public virtual IQueryable<T> All() {
            return _dbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate) {
            return _dbSet.Count(predicate) > 0;
        }

        public virtual T Create(T entity) {
            var newEntry = _dbSet.Add(entity);
            return newEntry;
        }

        public virtual void Delete(object id) {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity) {
            if (_dbContext.Entry(entity).State == EntityState.Detached) _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate) {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete) {
                if (_dbContext.Entry(entity).State == EntityState.Detached) _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate) {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) {
            var skipCount = index * size;
            var resetSet = filter != null ? _dbSet.Where(filter).AsQueryable() : _dbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public virtual T Find(params object[] keys) {
            return _dbSet.Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate) {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "") {
            IQueryable<T> query = _dbSet;

            if (filter != null) query = query.Where(filter);

            if (!string.IsNullOrWhiteSpace(includeProperties)) query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null) return orderBy(query).AsQueryable();
            return query.AsQueryable();
        }

        public virtual T GetById(object id) {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters) {
            return _dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual void Update(T entity) {
            var entry = _dbContext.Entry(entity);
            _dbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }
    }
}