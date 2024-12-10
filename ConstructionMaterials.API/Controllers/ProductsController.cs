using ConstructionMaterials.Application.Commands;
using ConstructionMaterials.Application.Queries;
using ConstructionMaterials.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] PaginationParameters paginationParameters)
    {
        var query = new GetProductsQuery { PaginationParameters = paginationParameters };
        var products = await _mediator.Send(query);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var product = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }
}