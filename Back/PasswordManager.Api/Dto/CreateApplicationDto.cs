namespace PasswordManager.Api.Dto;

/// <summary>
/// Data Transfer Object for creating a new Application.
/// </summary>
public class CreateApplicationDto
{
    public string ApplicationName { get; set; }
    public string ApplicationType { get; set; }
}