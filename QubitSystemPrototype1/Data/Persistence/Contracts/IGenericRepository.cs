namespace QubitSystemPrototype1.Data.Persistence.Contracts
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetById(string id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(string id);
    }
}
