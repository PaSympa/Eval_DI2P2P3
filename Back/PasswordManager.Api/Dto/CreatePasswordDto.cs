namespace PasswordManager.Api.Dto;

/// <summary>
/// Data Transfer Object for creating a new Password.
/// </summary>
public class CreatePasswordDto
{
    public string AccountName { get; set; }
    public string PlainPassword { get; set; }
    public int ApplicationId { get; set; }
}