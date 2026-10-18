namespace CoilMonitorWeb.Models;

public class DashboardDto
{
    public List<ServiceStatusDto> Services { get; set; } = new();

    public int QueueDepth { get; set; }
}

public class ServiceStatusDto
{
    public string Service { get; set; } = "";
    public string State { get; set; } = "";
    public DateTimeOffset HeartbeatDT { get; set; }
}

public class QueuedCoilDto
{
    public string CoilNumber { get; set; } = "";
    public DateTime QueuedTime { get; set; }
    public DateTime RunTime { get; set; }
}

public static class RequestStatus
{
    public const string Pending = "Pending";
    public const string Processing = "Processing";
    public const string Completed = "Completed";
    public const string Failed = "Failed";
}

public class CommandRequest
{
    public string RequestId { get; set; } = Guid.NewGuid().ToString();

    public string JobType { get; set; } = string.Empty;

    public string AuthTokenHash { get; set; } = string.Empty;

    public Dictionary<string, string> Parameters { get; set; } = new();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";
}