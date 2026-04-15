using CorsoCS.Core.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace CorsoCS.API.Controllers;

[ApiController]
[Route("/api/notes")]
public class NotesController(IMediator mediator) : ControllerBase
{
  [HttpPost]
  [ProducesResponseType<Guid>(200)]
  public async Task<IActionResult> CreateNote([FromBody] CreateNote command)
  {
    var result = await mediator.Send(command);
    return Ok(result);
  }

  // private readonly IMediator mediator;
  // public NotesController(IMediator mediator)
  // {
  //   this.mediator = mediator;

  // }
}