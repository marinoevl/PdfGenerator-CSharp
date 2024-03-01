using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PdfGenerator_CSharp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplateController: ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(ISender sender)
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ISender sender, Guid id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ISender sender)
    {
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ISender sender)
    {
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(ISender sender, Guid id)
    {
        return Ok();
    }
}