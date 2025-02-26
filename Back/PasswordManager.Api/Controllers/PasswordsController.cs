using Microsoft.AspNetCore.Mvc;
using PasswordManager.Api.Domain.Models;
using PasswordManager.Api.Dto;
using PasswordManager.Api.Services.Interfaces;

namespace PasswordManager.Api.Controllers;

/// <summary>
/// API controller for managing passwords.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PasswordsController : ControllerBase
{
    private readonly IPasswordService _passwordService;
    private readonly IApplicationService _applicationService;

    public PasswordsController(IPasswordService passwordService, IApplicationService applicationService)
    {
        _passwordService = passwordService;
        _applicationService = applicationService;
    }

    /// <summary>
    /// GET api/passwords
    /// Retrieves all stored passwords.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PasswordDto>>> GetPasswords()
    {
        var passwords = await _passwordService.GetAllPasswordsAsync();
        return Ok(passwords);
    }

    /// <summary>
    /// GET api/passwords/{id}
    /// Retrieves a password by its identifier.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<PasswordDto>> GetPasswordById(int id)
    {
        var password = await _passwordService.GetPasswordByIdAsync(id);
        if (password == null)
            return NotFound();
        return Ok(password);
    }

    /// <summary>
    /// POST api/passwords
    /// Adds a new password.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> AddPassword([FromBody] CreatePasswordDto password)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Retrieve the ApplicationType using the application ID from the DTO.
        ApplicationType appType;
        try
        {
            appType = await _applicationService.GetApplicationTypeByIdAsync(password.ApplicationId);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }

        // Pass the ApplicationType to the password service.
        await _passwordService.AddPasswordAsync(password, appType);
        return Ok();
    }

    /// <summary>
    /// DELETE api/passwords/{id}
    /// Deletes a password by its identifier.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePassword(int id)
    {
        var existingPassword = await _passwordService.GetPasswordByIdAsync(id);
        if (existingPassword == null)
            return NotFound();

        await _passwordService.DeletePasswordAsync(id);
        return NoContent();
    }
}