using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

public class ChartHub : Hub<IChartClient>
{

    public async Task<List<ChartModel>> GetChartData() => await Task.FromResult(DataManager.GetData());

    public async Task BroadcastChartData(List<ChartModel> data)
    {
        //log("data received from client is : {data});
        await Clients.All.NotifyChartDataUpdated(data);
    }
    // => await Clients.All.SendAsync("broadcastchartdata", data);

    public void Pause(float second){
        //
    }
}