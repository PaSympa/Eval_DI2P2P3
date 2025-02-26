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
    /// <returns> A collection of PasswordDto objects. </returns>
    Task<IEnumerable<PasswordDto>> GetAllPasswordsAsync();

    /// <summary>
    /// Retrieves all stored passwords, including the encrypted values.
    /// </summary>
    /// <returns> A collection of PasswordDto objects with encrypted passwords. </returns>
    Task<IEnumerable<PasswordDto>> GetEncryptedPasswordsAsync();

    /// <summary>
    /// Retrieves a password by its identifier.
    /// </summary>
    /// <param name="id"> The identifier of the password to retrieve. </param>
    /// <returns> A PasswordDto object. </returns>
    Task<PasswordDto> GetPasswordByIdAsync(int id);
    
    /// <summary>
    /// Retrieves the encrypted password by its identifier.
    /// </summary>
    /// <param name="id"> The identifier of the password to retrieve. </param>
    /// <returns> A PasswordDto object with the encrypted password. </returns>
    Task<PasswordDto> GetEncryptedPasswordByIdAsync(int id);

    /// <summary>
    /// Adds a new password. Business logic such as encryption can be applied here.
    /// </summary>
    Task AddPasswordAsync(CreatePasswordDto password, ApplicationType appType);

    /// <summary>
    /// Deletes a password by its identifier.
    /// </summary>
    Task DeletePasswordAsync(int id);
}