using backend_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace backend_dotnet.Controllers;

[ApiController]
[Route("/api/attachment")]
public class AttachmentController : ControllerBase
{
    private readonly ILogger<AttachmentController> _logger;
    private readonly IGenericService<Attachment> _attachmentService;

    public AttachmentController(ILogger<AttachmentController> logger, IGenericService<Attachment> attachmentService)
    {
        _logger = logger;
        _attachmentService = attachmentService;
    }

    [HttpGet]
    // Method inside controller is called Action
    public async Task<IEnumerable<Attachment>> Get()
    {
        try {
            return await _attachmentService.GetAll();
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
     public async Task<Attachment?> GetById(long id)
    {
        try {
            return await _attachmentService.GetById(id);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpPost]
     public async Task<Attachment> Create([FromBody] Attachment newAttachment)
    {
        try {
            return await _attachmentService.Create(newAttachment);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    [HttpPut]
     public async Task<Attachment> Put([FromBody] Attachment updateAttachment)
    {
        try {
            return await _attachmentService.Update(updateAttachment);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }


    [HttpDelete]
    [Route("{id}")]
     public async Task<Attachment?> Get(long id)
    {
        try {
            return await _attachmentService.Delete(id);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
}
