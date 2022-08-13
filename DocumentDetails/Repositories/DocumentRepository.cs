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
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
