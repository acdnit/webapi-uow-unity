namespace WebAPI_UOW.Models.Repository {
    public interface IUnitOfWork {
        IRepository<T> GetRepository<T>() where T : class;

        void Save();
    }
}