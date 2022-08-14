using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Repositories;
using DocumentDetails.Extensions;

namespace DocumentDetails.Services
{
    public class DocumentService
    {
        private readonly DocumentRepository _documentRepository;

        public DocumentService(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<List<DocumentView>> GetDocuments()
        {
            var documents = await _documentRepository.GetAll();
            return documents.ToDocumentView();
        }

        public async Task<List<DocumentView>> GetMainDocuments()
        {
            var documents = await _documentRepository.GetAll();
            return documents.Where(d => d.ParentId == null)
                .OrderBy(d=>d.Logs.First(l=>l.Event.Title=="Beérkezés").HappenedAt)
                .ToList().ToDocumentView();
        }

        public async Task<List<DocumentView>> GetDocumentChildren(int parentId)
        {
            var documents = await _documentRepository.GetChildrenById(parentId);
            return documents
                .OrderBy(d => d.Logs.First(l => l.Event.Title == "Létrehozás").HappenedAt)
                .ToList().ToDocumentView();
        }

        public async Task<List<DocumentEvent>> GetDocumentEvents(int documentId)
        {
            var document = await _documentRepository.GetById(documentId);
            return document.Logs.ToDocumentEvent();
        }

        public async Task<List<DocumentView>> GetDocumentsByTitle(string searchString)
        {
            var documents = await _documentRepository.GetAll();
            return documents
                .Where(d=>d.Title.ToLower().Contains(searchString.ToLower()))
                .ToList()
                .ToDocumentView();
        }
    }
}
