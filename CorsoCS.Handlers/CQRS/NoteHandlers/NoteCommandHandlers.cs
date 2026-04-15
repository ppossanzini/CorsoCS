using MediatR;
using CorsoCS.Core.Commands;
using CorsoCS.Handlers.Model;
using MapZilla;

namespace CorsoCS.Handlers.CQRS.NoteHandlers;

public class NoteCommandHandlers(DB db, IMapper mapper) :
  IRequestHandler<CreateNote, Guid>
{
  public async Task<Guid> Handle(CreateNote request, CancellationToken cancellationToken)
  {

    var note = mapper.Map<Model.Note>(request);
    note.Id = Guid.CreateVersion7();
    // var note = new Note()
    // {
    //   Body = request.Body,
    //   Date = request.Date,
    //   Title = request.Title,
    //   Id = Guid.CreateVersion7()
    // };
    db.Notes.Add(note) ;
    await db.SaveChangesAsync(cancellationToken);

    return note.Id;

  }
}