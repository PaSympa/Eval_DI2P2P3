using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Api.Domain.Models;

/**
 * Model that represents an application
 */
public class Application
{
    [Key]
    public int ApplicationId { get; set; }
        
    /**
     * Name of the application
     */
    [Required]
    [MaxLength(50)]
    public string ApplicationName { get; set; }
    
    /**
     * Type of the application
     */
    [Required]
    public ApplicationType ApplicationType { get; set; }
    
    public List<Password> Passwords { get; set; } = new();
}