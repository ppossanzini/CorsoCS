using Axon;

namespace CorsoCS.Core.Notifications;

public class NoteCreated: INotification
{
  public Guid Id { get; set; }
}