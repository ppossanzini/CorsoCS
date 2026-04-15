using MediatR;

namespace CorsoCS.Core.Query;

public class SearchNote: IRequest<IEnumerable<DTO.Note>>
{
  public string? Title { get; set; }
  public string? Body { get; set; }
}