using System.Globalization;
using Axon;
using CorsoCS.Core.DTO;
using CorsoCS.Core.Query;
using CorsoCS.Handlers.Model;
using MapZilla;
using MapZilla.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Note = CorsoCS.Core.DTO.Note;

namespace CorsoCS.Handlers.CQRS.NoteHandlers;

public class NoteQueryHandlers(DB db, IMapper mapper) :
  IRequestHandler<Core.Query.GetNote, Core.DTO.Note?>,
  IRequestHandler<Core.Query.SearchNote, PagedResults<Core.DTO.Note>>
{
  
  public async Task<Note?> Handle(GetNote request, CancellationToken cancellationToken)
  {
    var result = await db.Notes.Where(i => i.Id == request.Id)
      .FirstOrDefaultAsync(cancellationToken);

    // result = await (
    //   from n in db.Notes
    //   where n.Id == request.Id
    //   select n).FirstOrDefaultAsync(cancellationToken);

    if (result is null) return null;

    return mapper.Map<Core.DTO.Note>(result);

    // return new Note()
    // {
    //   Id = result.Id,
    //   Flagged = result.Flagged,
    //   Body = result.Body,
    //   Date = result.Date,
    //   Title = result.Title
    // };
    /*
     *SELECT TOP 1 * from note WHERE id = 'dddd'
     */
  }

  public async Task<PagedResults<Note>> Handle(SearchNote request, CancellationToken cancellationToken)
  {
    var query = db.Notes.AsQueryable();

    // if (request.Body != null) query = query.Where(i => i.Body.Contains(request.Body));
    // if (request.Title != null) query = query.Where(i => i.Title.Contains(request.Title));

    query = (from n in db.Notes
      where (request.Body == null || n.Body.Contains(request.Body)) ||
            (request.Title == null || n.Title.Contains(request.Title))
      select n);


    var count = await query.CountAsync(cancellationToken);

    return new PagedResults<Note>()
    {
      Items = await query.ProjectTo<Core.DTO.Note>(mapper.ConfigurationProvider)
        .Skip(request.Page * request.PageSize)
        .Take(request.PageSize)
        .ToListAsync(cancellationToken),
      Count = count,
      CurrentPage = request.Page
    };
  }
}