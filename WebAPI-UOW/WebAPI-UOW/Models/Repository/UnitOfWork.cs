using System;
using System.Data.Entity;
using System.Linq;

namespace WebAPI_UOW.Models.Repository {
    public class UnitOfWork {
        private readonly DbContext _dbContext;
        private bool _disposed;

        public UnitOfWork(DbContext context) {
            _dbContext = context;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class {
            return new Repository<T>(_dbContext);
        }

        public void Save() {
            if (_dbContext.GetValidationErrors().Any()) throw new Exception(_dbContext.GetValidationErrors().ToList()[0].ValidationErrors.ToList()[0].ErrorMessage);
            _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing) {
            if (!_disposed) if (disposing) _dbContext.Dispose();
            _disposed = true;
        }
    }
}