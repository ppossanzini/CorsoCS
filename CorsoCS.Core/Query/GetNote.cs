using MediatR;

namespace CorsoCS.Core.Query;

public class GetNote: IRequest<DTO.Note?>
{
  public Guid Id { get; set; }
}