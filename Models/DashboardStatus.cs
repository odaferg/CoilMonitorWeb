namespace CoilMonitorWeb.Models;

public class DashboardStatus
{
    public string Service { get; set; } = "";
    public string State { get; set; } = "";
    public DateTimeOffset HeartbeatDT { get; set; }
    public int QueueDepth { get; set; }
}