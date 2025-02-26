namespace PasswordManager.Api.Dto;

/// <summary>
/// Data Transfer Object for Password entity (output).
/// </summary>
public class PasswordDto
{
    public int PasswordId { get; set; }
    public string AccountName { get; set; }
    public string EncryptedPassword { get; set; }
    public int ApplicationId { get; set; }
    
    // Optional
    public ApplicationDto Application { get; set; }
}