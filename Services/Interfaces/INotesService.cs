using backend_dotnet.Models;

namespace Services.Interfaces {
    public interface INotesService {
         Task<IEnumerable<Note>> GetNotes();
        Task<Note?> GetById(long id);
        Task<Note> Create(Note newNote);
        Task<Note> Update(Note updateNote);
        Task<Note?> Delete(long id);
    }
}