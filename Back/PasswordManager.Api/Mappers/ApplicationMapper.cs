using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;

namespace PasswordManager.Api.Mappers;

/// <summary>
/// Manual mapper for converting between Application entity and its DTOs.
/// </summary>
public static class ApplicationMapper
{
    /// <summary>
    /// Maps an Application entity to an ApplicationDto.
    /// </summary>
    public static ApplicationDto ToDto(Application app)
    {
        if (app == null) return null;
            
        return new ApplicationDto
        {
            ApplicationId = app.ApplicationId,
            ApplicationName = app.ApplicationName,
            ApplicationType = app.ApplicationType.ToString()
        };
    }

    /// <summary>
    /// Maps a CreateApplicationDto to an Application entity.
    /// </summary>
    public static Application ToEntity(CreateApplicationDto dto)
    {
        if (dto == null) return null;
            
        return new Application
        {
            ApplicationName = dto.ApplicationName,
            ApplicationType = (ApplicationType)Enum.Parse(typeof(ApplicationType), dto.ApplicationType, ignoreCase: true)
        };
    }
}