using App.Templates.Create;
using App.Templates.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public async Task<IActionResult> Create(ISender sender, CreateTemplateCommand request)
    {
        await sender.Send(request);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(ISender sender)
    {
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(ISender sender, Guid id)
    {
        await sender.Send(new DeleteTemplateCommand(id));
        return NoContent();
    }
}