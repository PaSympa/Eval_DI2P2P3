using Microsoft.AspNetCore.Mvc;
using PasswordManager.Api.Dto;
using PasswordManager.Api.Services.Interfaces;

namespace PasswordManager.Api.Controllers;

/// <summary>
/// API Controller for managing applications.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    /// <summary>
    /// GET api/applications
    /// Retrieves a list of all applications.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplications()
    {
        var applications = await _applicationService.GetAllApplicationsAsync();
        return Ok(applications);
    }

    /// <summary>
    /// POST api/applications
    /// Creates a new application.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ApplicationDto>> CreateApplication([FromBody] CreateApplicationDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdApp = await _applicationService.CreateApplicationAsync(createDto);
        return CreatedAtAction(nameof(GetApplications), new { id = createdApp.ApplicationId }, createdApp);
    }
}