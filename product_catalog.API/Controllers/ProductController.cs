using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_catalog.API.Requests;
using product_catalog.Application.ProductCQRS.Commands;
using product_catalog.Application.ProductCQRS.Queries;

namespace product_catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    public ProductController(IMapper mapper, IMediator mediator, ILogger<ProductController> logger)
    {
        _mapper = mapper;
        _mediator = mediator;
        _logger = logger;
    }

    [Authorize(Policy = "User and advanced user")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var product = _mapper.Map<CreateProductCommand>(request);
        await _mediator.Send(product);
        _logger.LogInformation("Created successful");
        return Ok();
    }

    [Authorize(Policy = "Advanced user")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int productId)
    {
        await _mediator.Send(new DeleteProductCommand(productId));
        _logger.LogInformation("Deleted successful");
        return Ok();
    }

    [Authorize(Policy = "User and advanced user")]
    [HttpPost("change")]
    public async Task<IActionResult> Change([FromBody] ChangeProductRequest request)
    {
        var product = _mapper.Map<ChangeProductCommand>(request);
        await _mediator.Send(product);
        _logger.LogInformation("Changed successful");
        return Ok();
    }

    [Authorize(Policy = "Authenticated")]
    [HttpGet]
    public async Task<IActionResult> GetAll(string? title, int? categoryId)
    {
        var result = await _mediator.Send(new GetAllProductsQuery(title, categoryId));
        _logger.LogInformation("GetAll successful");
        return Ok(result);
    }
}
