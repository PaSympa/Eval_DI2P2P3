using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Repositories.Context;
using PasswordManager.Api.Repositories.Interfaces;

namespace PasswordManager.Api.Repositories;

/// <summary>
/// Implementation of IPasswordRepository using EF Core
/// This class is responsible for managing Password entities in the database
/// </summary>
public class PasswordRepository : IPasswordRepository
{
    private readonly PasswordManagerDbContext _context;
    
    public PasswordRepository(PasswordManagerDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Password>> GetAllPasswordsAsync()
    {
        return await _context.Passwords
            .Include(p => p.Application)
            .ToListAsync();
    }

    public async Task<Password> GetPasswordByIdAsync(int id)
    {
        return await _context.Passwords
            .Include(p => p.Application)
            .FirstOrDefaultAsync(p => p.PasswordId == id);
    }

    public async Task AddPasswordAsync(Password password)
    {
        _context.Passwords.Add(password);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePasswordAsync(int id)
    {
        var password = await _context.Passwords.FindAsync(id);
        if (password != null)
        {
            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();
        }
    }
}