using backend_dotnet.Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services {
    public class NotesService: INotesService {

        // Repository variable that is null at the moment
       private readonly IGenericRepository<Note> _notesRepository;

        // Dependency Injection (DI), injecting repository to our service
        public NotesService(IGenericRepository<Note> noteRepository)
        {
            // initialize the repository
            _notesRepository = noteRepository;
        } 

        // Get All notes method, that call the notesRepository intance.
        public async Task<IEnumerable<Note>> GetNotes() {
            return await _notesRepository.GetAll();
        }
    }
}