using Microsoft.EntityFrameworkCore;
using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Repositories.Context;
using PasswordManager.Api.Repositories.Interfaces;

namespace PasswordManager.Api.Repositories;

/// <summary>
/// Implementation of IApplicationRepository using EF Core.
/// </summary>
public class ApplicationRepository : IApplicationRepository
{
    private readonly PasswordManagerDbContext _context;

    public ApplicationRepository(PasswordManagerDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
    {
        return await _context.Applications.ToListAsync();
    }

    public async Task AddApplicationAsync(Application app)
    {
        _context.Applications.Add(app);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Application> GetApplicationByIdAsync(int id)
    {
        return await _context.Applications.FirstOrDefaultAsync(a => a.ApplicationId == id);
    }
}