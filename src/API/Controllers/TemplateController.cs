using App.Templates.Create;
using App.Templates.Delete;
using App.Templates.Exports;
using App.Templates.GetAll;
using App.Templates.GetById;
using App.Templates.Update;
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
        return Ok(await sender.Send(new GetAllTemplateQuery()));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(ISender sender, Guid id)
    {
        return Ok(await sender.Send(new GetByIdTemplateQuery(id)));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ISender sender, CreateTemplateCommand request)
    {
        await sender.Send(request);
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(ISender sender, [FromRoute] Guid id, [FromBody] string content)
    {
        await sender.Send(new UpdateTemplateCommand(id, content));
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ISender sender, Guid id)
    {
        await sender.Send(new DeleteTemplateCommand(id));
        return NoContent();
    }
    
    [HttpGet("GeneratePdf")]
    public async Task<IActionResult> Get(ISender sender, [FromBody] GeneratePdfQuery request)
    {
        return Ok(await sender.Send(request));
    }
}