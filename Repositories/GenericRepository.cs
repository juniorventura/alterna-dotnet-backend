using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories {
    // T is the type of the class we are using. 
    public class GenericRepository<T>: IGenericRepository<T> where T: class {

        // TODO:  Reference of the dbContext, similar to primsa client.
        // TODO: Define generic methods for CRUD

        // This _context is the equivalent to prisma in our node.js app
        // this variable is not initialized yet
        private readonly DotnetTestContext _context;

        public GenericRepository(DotnetTestContext context)
        {
            // Initialize the value using Dependency Injection.
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll() {
        
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> Get(long id) {
        
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity) {
        
            _context.Set<T>().Add(entity);
            // TODO: Implement Unit Of Work
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity) {
        
            _context.Entry(entity).State = EntityState.Modified;
            // TODO: Implement Unit Of Work
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> Delete(long id) {
        
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity is null) return entity;

            _context.Set<T>().Remove(entity);
            // TODO: Implement Unit Of Work
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}