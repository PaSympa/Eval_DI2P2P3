using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Api.Domain.Models;

/**
 * Model that represents a password
 */
public class Password
{
    [Key]
    public int PasswordId { get; set; }
        
    /// <summary>
    /// Name of the account
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string AccountName { get; set; }
        
    /// <summary>
    /// Encrypted password
    /// </summary>
    [Required]
    public string EncryptedPassword { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [ForeignKey("ApplicationId")]
    public Application Application { get; set; }
}