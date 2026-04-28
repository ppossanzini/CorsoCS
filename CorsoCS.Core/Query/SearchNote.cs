using Axon;
using CorsoCS.Core.DTO;

namespace CorsoCS.Core.Query;

public class SearchNote: IRequest<PagedResults<DTO.Note>>
{
  public string? Title { get; set; }
  public string? Body { get; set; }

  public int Page { get; set; } = 0;
  public int PageSize { get; set; } = 10;
}