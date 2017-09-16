namespace WebAPI_UOW.Models.Repository {
    public interface IApiUnitOfWork {
        IRepository<T> GetRepository<T>() where T : class;

        void Save();

        void Dispose();
    }
}