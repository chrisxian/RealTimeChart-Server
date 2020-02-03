using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// client's methods called by server
/// </summary>
public interface IChartClient
{
    public Task NotifyChartDataUpdated(List<ChartModel> data);
}