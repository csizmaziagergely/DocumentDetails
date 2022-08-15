using DocumentDetails.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentDetails.Repositories
{
    public class UserRepository
    {
        private readonly DocumentDetailsContext _context;

        public UserRepository(DocumentDetailsContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstAsync(u => u.Id == id);
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstAsync(u => u.UserName == userName);
        }
        public async Task Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateById(int id)
        {
            var userToDeactivate = await GetById(id);
            userToDeactivate.IsActive = false; 
            await _context.SaveChangesAsync();
        }
    }
}
