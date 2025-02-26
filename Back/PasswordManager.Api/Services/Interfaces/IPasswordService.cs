using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;

namespace PasswordManager.Api.Services.Interfaces;

/// <summary>
/// Service interface for managing passwords.
/// </summary>
public interface IPasswordService
{
    /// <summary>
    /// Retrieves all stored passwords.
    /// </summary>
    Task<IEnumerable<PasswordDto>> GetAllPasswordsAsync();

    /// <summary>
    /// Retrieves a password by its identifier.
    /// </summary>
    Task<PasswordDto> GetPasswordByIdAsync(int id);

    /// <summary>
    /// Adds a new password. Business logic such as encryption can be applied here.
    /// </summary>
    Task AddPasswordAsync(CreatePasswordDto password, ApplicationType appType);

    /// <summary>
    /// Deletes a password by its identifier.
    /// </summary>
    Task DeletePasswordAsync(int id);
}