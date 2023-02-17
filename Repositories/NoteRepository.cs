using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories {
    public class NoteRepository: INoteRepository {

        private readonly DotnetTestContext _dbContext;
        public NoteRepository(DotnetTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 
        public async Task<IEnumerable<Note>> GetByCustomScenario() {

            // IQueryable is an in-memory query, is not executed yet.

            // LINQ syntax
            var query = from n in _dbContext.Notes
                        join a in _dbContext.Attachments on n.NoteId equals a.NoteId
                        where n.Description.Length > 0
                        select n;

            return await query.ToListAsync();
        }
    }
}