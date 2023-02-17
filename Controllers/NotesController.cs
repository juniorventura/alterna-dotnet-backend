using backend_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace backend_dotnet.Controllers;

[ApiController]
[Route("/api/notes")]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;
    private readonly IGenericService<Note> _notesService;

    public NotesController(ILogger<NotesController> logger, IGenericService<Note> notesService)
    {
        _logger = logger;
        _notesService = notesService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // Method inside controller is called Action
    public async Task<IEnumerable<Note>> Get()
    {
        try {
            return await _notesService.GetAll();
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
     public async Task<Note?> GetById(long id)
    {
        try {
            return await _notesService.GetById(id);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpPost]
     public async Task<Note> Create([FromBody] Note newNote)
    {
        try {
            return await _notesService.Create(newNote);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpPut]
     public async Task<Note> Put([FromBody] Note updateNote)
    {
        try {
            return await _notesService.Update(updateNote);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }


    [HttpDelete]
    [Route("{id}")]
     public async Task<Note?> Get(long id)
    {
        try {
            return await _notesService.Delete(id);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
}
