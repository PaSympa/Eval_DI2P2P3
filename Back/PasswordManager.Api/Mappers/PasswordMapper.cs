using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;

namespace PasswordManager.Api.Mappers;

/// <summary>
/// Manual mapper for converting between Password entity and its DTOs.
/// </summary>
public class PasswordMapper
{
    /// <summary>
    /// Maps a Password entity to a PasswordDto.
    /// </summary>
    public static PasswordDto ToDto(Password password)
    {
        return new PasswordDto
        {
            PasswordId = password.PasswordId,
            AccountName = password.AccountName,
            EncryptedPassword = password.EncryptedPassword,
            ApplicationId = password.ApplicationId,
            Application = ApplicationMapper.ToDto(password.Application)
        };
    }

    /// <summary>
    /// Maps a CreatePasswordDto to a Password entity.
    /// Note: The plain password should be encrypted in the service before persisting.
    /// </summary>
    public static Password ToEntity(CreatePasswordDto dto)
    {
        return new Password
        {
            AccountName = dto.AccountName,
            EncryptedPassword = dto.PlainPassword, // This should be encrypted in the service
            ApplicationId = dto.ApplicationId
        };
    }
}