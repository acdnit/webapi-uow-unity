using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI_UOW.Models.Repository {
    public interface IRepository<T> where T : class {
        int Count { get; }

        IQueryable<T> All();

        bool Contains(Expression<Func<T, bool>> predicate);

        T Create(T entity);

        void Delete(object id);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> predicate);

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        T Find(params object[] keys);

        T Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        T GetById(object id);

        IEnumerable<T> GetWithRawSql(string query, params object[] parameters);

        void Update(T entity);
    }
}