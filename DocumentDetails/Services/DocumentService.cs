using DocumentDetails.Entities;
using DocumentDetails.Repositories;

namespace DocumentDetails.Services
{
    public class DocumentService
    {
        private readonly DocumentRepository _documentRepository;

        public DocumentService(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<Document>> GetDocuments()
        {
            return (await _documentRepository.GetAll());
        }
    }
}
