using Microsoft.AspNetCore.SignalR;

namespace CorsoCS.API.Hubs;

public class NotesHub : Hub
{
  public Task SubscribeToNotesEvents()
  {
    return this.Groups.AddToGroupAsync(
      this.Context.ConnectionId,
      nameof(Core.Notifications.NoteCreated)
    );
  }
}