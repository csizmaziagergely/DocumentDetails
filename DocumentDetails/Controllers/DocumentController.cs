using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentDetails.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DocumentView>>> GetAll()
        {
            var documents = await _documentService.GetDocuments();
            return Ok(documents);
        }
        [HttpGet("main")]
        public async Task<ActionResult<List<DocumentView>>> GetAllMain()
        {
            var documents = await _documentService.GetMainDocuments();
            return Ok(documents);
        }

        [HttpGet("{id}/children")]
        public async Task<ActionResult<List<DocumentView>>> GetChildrenById(int id)
        {
            try
            {
                var documents = await _documentService.GetDocumentChildren(id);
                return Ok(documents);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/events")]
        public async Task<ActionResult<List<DocumentEvent>>> GetEventsById(int id)
        {
            try
            {
                var events = await _documentService.GetDocumentEvents(id);
                return Ok(events);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<DocumentEvent>>> GetDocumentsByTitle([FromQuery] string searchString)
        {
            try
            {
                var events = await _documentService.GetDocumentsByTitle(searchString);
                return Ok(events);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


    }
}
