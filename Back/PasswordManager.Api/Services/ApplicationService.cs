using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;
using PasswordManager.Api.Mappers;
using PasswordManager.Api.Repositories.Interfaces;
using PasswordManager.Api.Services.Interfaces;

namespace PasswordManager.Api.Services;

/// <summary>
/// Implementation of IApplicationService for managing applications.
/// </summary>
public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync()
    {
        var apps = await _applicationRepository.GetAllApplicationsAsync();
        return apps.Select(a => ApplicationMapper.ToDto(a));
    }

    public async Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createDto)
    {
        // Map DTO to domain entity using the manual mapper
        var appEntity = ApplicationMapper.ToEntity(createDto);
        await _applicationRepository.AddApplicationAsync(appEntity);
        return ApplicationMapper.ToDto(appEntity);
    }
    
    public async Task<ApplicationType> GetApplicationTypeByIdAsync(int id)
    {
        var app = await _applicationRepository.GetApplicationByIdAsync(id);
        if (app == null)
        {
            throw new KeyNotFoundException($"Application with id {id} not found.");
        }
        return app.ApplicationType;
    }
}