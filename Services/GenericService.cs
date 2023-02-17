using Repositories.Interfaces;
using Services.Interfaces;

namespace Services {
    public class GenericService<T>: IGenericService<T> where T: class {

        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<T>> GetAll() {
            return await _genericRepository.GetAll();
        }

        public async Task<T?> GetById(long id) {
            return await _genericRepository.Get(id);
        }

        public async Task<T> Create(T entity) {
            return await _genericRepository.Add(entity);
        }

        public async Task<T> Update(T entity) {
            return await _genericRepository.Update(entity);
        }

        public async Task<T?> Delete(long id) {
            return await _genericRepository.Delete(id);
        }
    }
}