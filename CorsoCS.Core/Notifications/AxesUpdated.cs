using Axon;

namespace CorsoCS.Core.Notifications;

public class AxesUpdated: INotification
{
  public int X { get; set; }
  public int Y { get; set; }
  public int R { get; set; }
}