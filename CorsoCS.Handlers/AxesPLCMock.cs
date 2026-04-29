using Axon;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CorsoCS.Handlers;

public class AxesPLCMock(IAxon mediator, ILogger<AxesPLCMock> logger) : IHostedService
{
  private Timer _timer;
  private Random _random = new();

  private double x = 0;
  private double y = 0;
  private double d = 0;

  public Task StartAsync(CancellationToken cancellationToken)
  {
    _timer = new Timer(
      callback: (state) =>
      {
        x +=  _random.NextDouble() * 100 - 50;
        y += _random.NextDouble() * 100 - 50;

        x = Math.Max(Math.Min(1300, x),0);
        y = Math.Max(Math.Min(3700, y), 0);
        
        // logger.LogInformation($"x: {x} y: {y}");
        
        mediator.Publish(new Core.Notifications.AxesUpdated()
        {
          X = (int)x,
          Y = (int)y,
        });
      },
      state: null,
      dueTime: TimeSpan.Zero,
      period: TimeSpan.FromMilliseconds(50)
    );


    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }
}