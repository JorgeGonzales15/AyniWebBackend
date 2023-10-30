using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Shared.Persistence.Contexts;
using AyniWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Ayni.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public void Update(User user)
    {
        _context.Users.Update(user);
    }
    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

}