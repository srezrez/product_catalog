using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_catalog.API.Requests;
using product_catalog.Application.CategoryCQRS.Commands;
using product_catalog.Application.CategoryCQRS.Queries;

namespace product_catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [Authorize(Policy = "Authenticated")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        _logger.LogInformation("GetAll successful");
        return Ok(result);
    }

    [Authorize(Policy = "Advanced user")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int categoryId)
    {
        await _mediator.Send(new DeleteCategoryCommand(categoryId));
        _logger.LogInformation("Deleted successful");
        return Ok();
    }

    [Authorize(Policy = "Advanced user")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        await _mediator.Send(new CreateCategoryCommand(request.Title));
        _logger.LogInformation("Created successful");
        return Ok();
    }

    [Authorize(Policy = "Advanced user")]
    [HttpPost("change")]
    public async Task<IActionResult> Change([FromBody] ChangeCategoryRequest request)
    {
        await _mediator.Send(new ChangeCategoryCommand(request.Id, request.Title));
        _logger.LogInformation("Changed successful");
        return Ok();
    }
}
