using backend_dotnet.Models;

namespace Services.Interfaces {
    public interface INotesService {
         Task<IEnumerable<Note>> GetNotes();
    }
}