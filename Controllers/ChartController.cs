using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


[Route("api/[controller]")]
[ApiController]
public class ChartController : ControllerBase
{
    private IHubContext<ChartHub, IChartClient> _hub;

    public ChartController(IHubContext<ChartHub, IChartClient> hub)
    {
        _hub = hub;
    }

    // ChartController(webapi) has to be used, becuase the timer has to be started trigger by the client, but the Hub instance is instanciated per each request,
    // and the HubConext has to be injected by ASP.NET Core DI service.
    public IActionResult Get()
    {
        var timerManager = new TimerManager(() => _hub.Clients.All.NotifyChartDataUpdated(DataManager.GetData()));

        return Ok(new { Message = "Request Completed" });
    }
}