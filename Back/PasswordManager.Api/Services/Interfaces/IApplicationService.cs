using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;

namespace PasswordManager.Api.Services.Interfaces;

/// <summary>
/// Service interface for managing Application business logic.
/// </summary>
public interface IApplicationService
{
    /// <summary>
    /// Retrieves all applications as DTOs.
    /// </summary>
    Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync();

    /// <summary>
    /// Creates a new application from the provided DTO.
    /// </summary>
    Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createDto);
    
    /// <summary>
    /// Retrieves the ApplicationType for a given Application ID.
    /// </summary>
    Task<ApplicationType> GetApplicationTypeByIdAsync(int id);
}