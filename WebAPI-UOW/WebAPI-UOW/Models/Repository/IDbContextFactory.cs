using System.Data.Entity;

namespace WebAPI_UOW.Models.Repository {
    public interface IDbContextFactory {
        DbContext GetDbContext();
    }
}