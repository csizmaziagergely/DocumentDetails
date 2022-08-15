using DocumentDetails.DTOs;
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
                .Include(u=> u.Logs)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users
                .Include(u => u.Logs)
                .AsNoTracking()
                .FirstAsync(u => u.Id == id);
        }

        public async Task<User> GetByUserName(string userName)
        {

            return await _context.Users
                .Include(u => u.Logs)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }
        public async Task Add(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> DeactivateUser(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddLog(UserLog entity)
        {
            await _context.UserLogs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
