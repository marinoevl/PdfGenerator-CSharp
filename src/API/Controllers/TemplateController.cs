using App.Templates.Commands.Create;
using App.Templates.Commands.Delete;
using App.Templates.Commands.Update;
using App.Templates.Queries.Exports;
using App.Templates.Queries.GetAll;
using App.Templates.Queries.GetById;
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