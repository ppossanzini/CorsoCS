using Axon;
using CorsoCS.Core.Commands;
using CorsoCS.Handlers.Model;
using MapZilla;

namespace CorsoCS.Handlers.CQRS.NoteHandlers;

public class NoteCommandHandlers(
  DB db,
  IMapper mapper,
  IAxon mediator) :
  IRequestHandler<CreateNote, Guid>
{
  public async Task<Guid> Handle(CreateNote request, CancellationToken cancellationToken)
  {
    var note = mapper.Map<Model.Note>(request);
    note.Id = Guid.CreateVersion7();
    note.UserName = "system";
    note.Flagged = false;
    // var note = new Note()
    // {
    //   Body = request.Body,
    //   Date = request.Date,
    //   Title = request.Title,
    //   Id = Guid.CreateVersion7()
    // };
    db.Notes.Add(note) ;
    await db.SaveChangesAsync(cancellationToken);

    await mediator.Publish(new Core.Notifications.NoteCreated()
    {
      Id = note.Id
    }, cancellationToken);


    return note.Id;
  }
}