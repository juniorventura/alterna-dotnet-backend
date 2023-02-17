namespace Services.Interfaces {
    public interface IGenericService<T> {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T?> Delete(long id);
    }
}