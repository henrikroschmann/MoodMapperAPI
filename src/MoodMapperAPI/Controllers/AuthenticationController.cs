using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using MoodMapperAPI.Domain.Models;

namespace MoodMapperAPI.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AuthenticationController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var result = await _accountService.CreateUser(model);
            if (result.Succeeded)
            {
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message, e);
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _accountService.AuthenticateUser(model);
            var token = await _accountService.GetToken(result);
            return Ok(new JwtTokenResponse { Token = token });
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized();
        }
        catch
        {
            return BadRequest("Invalid user request");
        }
    }

    /// <summary>
    /// Delete a user
    /// Organization User: Remove user relations with organization.
    /// User: Delete the user
    /// </summary>
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete()
    {
        try
        {
            var user = User?.Identity?.Name;
            Guard.IsNotNullOrEmpty(user);

            await _accountService.DeleteUser(user);

            HttpContext.Session.Clear();

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
