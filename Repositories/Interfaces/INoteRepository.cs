using backend_dotnet.Models;

namespace Repositories.Interfaces {
    public interface INoteRepository {
        Task<IEnumerable<Note>> GetByCustomScenario();
    }
}