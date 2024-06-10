using Microsoft.AspNetCore.Mvc;
using product_catalog.NBRB.Contracts;

namespace product_catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExchangeController : ControllerBase
{
    private readonly IRateProvider _rateProvider;

    public ExchangeController(IRateProvider rateProvider)
    {
        _rateProvider = rateProvider;
    }

    [HttpGet]
    public async Task<IActionResult> Convert(decimal price, string currency)
    {
        var result = await _rateProvider.ConvertValueToCurrency(price, currency);
        return Ok(result);
    }
}
