using Axon;
using CorsoCS.Core.Commands;
using CorsoCS.Core.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace CorsoCS.API.Controllers;

[ApiController]
[Route("/api/notes")]
public class NotesController(IAxon mediator) : ControllerBase
{
  [HttpPost]
  [ProducesResponseType<Guid>(200)]
  public async Task<IActionResult> CreateNote([FromBody] CreateNote command)
  {
    var result = await mediator.Send(command);
    return Ok(result);
  }

  [HttpGet]
  [Route("{id:guid}")]
  [ProducesResponseType<Core.DTO.Note>(200)]
  [ProducesResponseType(404)]
  public async Task<IActionResult> GetNote(Guid id)
  {
    var result = await mediator.Send(new Core.Query.GetNote() { Id = id });
    if (result == null) return NotFound();
    return Ok(result);
  }

  [HttpGet]
  [Route("search")]
  public async Task<PagedResults<Core.DTO.Note>>
    SearchNote(string? title, string? body, int? page, int? pageSize)
  {
    var result = await mediator.Send(new Core.Query.SearchNote()
    {
      Body = body,
      Title = title, 
      Page = page ?? 0 ,
      PageSize = pageSize ?? 10
    });
    return result;
  }
}