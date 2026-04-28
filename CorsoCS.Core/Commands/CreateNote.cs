using Axon;

namespace CorsoCS.Core.Commands;

public class CreateNote: IRequest<Guid>
{
  public DateTime Date { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
}