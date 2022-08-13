using DocumentDetails.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentDetails.Repositories
{
    public class DocumentRepository
    {
        private readonly DocumentDetailsContext _context;

        public DocumentRepository(DocumentDetailsContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetAll()
        {
            return await _context.Documents
                .Include(d=>d.Logs)
                    .ThenInclude(dl=>dl.Event)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Document> GetById(int id)
        {
            return await _context.Documents
                .AsNoTracking()
                .Include(d => d.Logs)
                    .ThenInclude(dl => dl.Event)
                .FirstAsync(d=>d.Id==id);
        }

        public async Task<List<Document>> GetChildrenById(int parentId)
        {
            return await _context.Documents
                .Where(d => d.ParentId == parentId)
                .Include(d => d.Logs)
                    .ThenInclude(dl => dl.Event)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
