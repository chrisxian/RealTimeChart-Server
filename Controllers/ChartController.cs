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

    public IActionResult Get()
    {
        var timerManager = new TimerManager(() => _hub.Clients.All.NotifyChartDataUpdated(DataManager.GetData()));

        return Ok(new { Message = "Request Completed" });
    }
}