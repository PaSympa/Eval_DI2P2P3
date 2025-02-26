using Microsoft.AspNetCore.Mvc;
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

        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
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

            await _passwordService.AddPasswordAsync(password);
            // In a real-world scenario, you might return the created entity with its new id.
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