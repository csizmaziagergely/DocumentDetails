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
        public async Task<ActionResult<List<Document>>> GetAll()
        {
            var documents = await _documentService.GetDocuments();
            return documents;
        }
    }
}
