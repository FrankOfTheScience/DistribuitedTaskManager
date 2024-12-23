using DistribuitedTaskManager.Models;
using DistribuitedTaskManager.Services;
using DistribuitedTaskManager.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DistribuitedTaskManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
        => _configuration = configuration;

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var user = AuthenticateUser(model.Username, model.Password);
        if (user is null)
            return Unauthorized("Invalid credentials");

        var token = AuthTools.GenerateJwtToken(user, _configuration);
        return Ok(new { token });
    }

    // This method should be implemented in a real application through a call to a database
    private LoginModel? AuthenticateUser(string username, string password)
    {
        if (username == "admin" && password == "admin")
            return new LoginModel { Username = username };

        return null;
    }
}