using PasswordManager.Api.Domain.Models;

namespace PasswordManager.Api.Repositories.Interfaces;

/// <summary>
/// Interface for accessing Password entities from the database
/// </summary>
public interface IPasswordRepository
{
    /// <summary>
    /// Retrieves all passwords
    /// </summary>
    Task<IEnumerable<Password>> GetAllPasswordsAsync();

    /// <summary>
    /// Retrieves a password by its identifier
    /// </summary>
    Task<Password> GetPasswordByIdAsync(int id);

    /// <summary>
    /// Adds a new password to the database
    /// </summary>
    Task AddPasswordAsync(Password password);

    /// <summary>
    /// Deletes a password by its identifier
    /// </summary>
    Task DeletePasswordAsync(int id);
}