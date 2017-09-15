using System.Data.Entity;

namespace WebAPI_UOW.Models.Repository {
    public class DbContextFactory<T> : IDbContextFactory where T : DbContext, new() {
        private readonly DbContext _context;

        public DbContextFactory() {
            _context = new T();
        }

        public DbContext GetDbContext() {
            return _context;
        }
    }
}