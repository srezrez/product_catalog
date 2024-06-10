using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_catalog.API.Requests;
using product_catalog.API.Responses;
using product_catalog.API.Services.Contracts;
using product_catalog.Application.UserCQRS.Commands;
using product_catalog.Application.UserCQRS.Queries;

namespace product_catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IJwtTokenBuilder _jwtTokenBuilder;
    private readonly ILogger _logger;

    public UserController(IMapper mapper, IMediator mediator, IJwtTokenBuilder jwtTokenBuilder, ILogger<UserController> logger)
    {
        _mapper = mapper;
        _mediator = mediator;
        _jwtTokenBuilder = jwtTokenBuilder;
        _logger = logger;
    }

    [Authorize(Policy = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        _logger.LogInformation("GetAll successful");
        return Ok(_mapper.Map<IReadOnlyCollection<UserResponse>>(result));
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int userId)
    {
        await _mediator.Send(new DeleteUserCommand(userId));
        _logger.LogInformation("Deleted successful");
        return Ok();
    }

    [Authorize(Policy = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var command = _mapper.Map<CreateUserCommand>(request);
        await _mediator.Send(command);
        _logger.LogInformation("Created successful");
        return Ok();
    }

    [Authorize(Policy = "Admin")]
    [HttpPost("change-status")]
    public async Task<IActionResult> ChangeStatus(int userId)
    {
        await _mediator.Send(new ChangeUserStatusCommand(userId));
        _logger.LogInformation("Status changed successful");
        return Ok();
    }

    [Authorize(Policy = "Admin")]
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var command = _mapper.Map<ChangePasswordCommand>(request);
        await _mediator.Send(command);
        _logger.LogInformation("Password changed successful");
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var command = _mapper.Map<AuthenticateUserCommand>(request);
        var result = await _mediator.Send(command);

        var jwtToken = _jwtTokenBuilder
            .AddUserIdClaim(result.UserId.ToString())
            .AddRoleClaim(result.Role.ToString())
            .Build();
        _logger.LogInformation($"User {result.UserId} authenticated");
        var response = new LoginResponse(result.UserId, result.Role, "Bearer " + jwtToken );
        return Ok(response);
    }

}
