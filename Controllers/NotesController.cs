using backend_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace backend_dotnet.Controllers;

[ApiController]
[Route("/api/notes")]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;
    private readonly INotesService _notesService;

    public NotesController(ILogger<NotesController> logger, INotesService notesService)
    {
        _logger = logger;
        _notesService = notesService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // Method inside controller is called Action
    public async Task<IEnumerable<Note>> Get()
    {
        try {
            return await _notesService.GetNotes();
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
}
