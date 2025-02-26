namespace PasswordManager.Api.Dto;

/// <summary>
/// Data Transfer Object for Application entity (output).
/// </summary>
public class ApplicationDto
{
    public int ApplicationId { get; set; }
    public string ApplicationName { get; set; }
    public string ApplicationType { get; set; }
}