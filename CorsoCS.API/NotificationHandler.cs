using Axon;
using CorsoCS.API.Hubs;
using CorsoCS.Core.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace CorsoCS.API;

public class NotificationHandler(
  IHubContext<NotesHub> notesContext) :
  INotificationHandler<Core.Notifications.NoteCreated>
{
  public Task Handle(
    NoteCreated notification,
    CancellationToken cancellationToken)
  {
    return
    notesContext.Clients.Groups(nameof(Core.Notifications.NoteCreated))
      .SendAsync("noteCreated", notification, cancellationToken);
    
  }
}