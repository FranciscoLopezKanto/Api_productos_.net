using CrudMongoApi.Models;
using CrudMongoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudMongoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
        => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(string id)
    {
        var p = await _service.GetByIdAsync(id);
        return p is null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product p)
    {
        var created = await _service.CreateAsync(p);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Product p)
    {
        var ok = await _service.UpdateAsync(id, p);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}