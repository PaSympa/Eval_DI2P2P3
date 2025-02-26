using PasswordManager.Api.Domain.Models;

namespace PasswordManager.Api.Repositories.Interfaces;

/// <summary>
/// Interface for accessing Application data from the database.
/// </summary>
public interface IApplicationRepository
{
    /// <summary>
    /// Retrieves all Application entities.
    /// </summary>
    Task<IEnumerable<Application>> GetAllApplicationsAsync();

    /// <summary>
    /// Adds a new Application entity.
    /// </summary>
    Task AddApplicationAsync(Application app);
    
    /// <summary>
    /// Retrieves an Application by its identifier.
    /// </summary>
    Task<Application> GetApplicationByIdAsync(int id);
}