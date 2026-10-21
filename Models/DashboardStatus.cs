namespace CoilMonitorWeb.Models;

public class DashboardDto
{
    public List<ServiceStatusDto> Services { get; set; } = new();

    public int PendingQueue { get; set; }
    public int CompletedQueue { get; set; }
    public int FailedQueue { get; set; }
}

public class ServiceStatusDto
{
    public string Service { get; set; } = "";
    public string State { get; set; } = "";
    public DateTimeOffset HeartbeatDT { get; set; }
}

public class DailySummary
{
    public List<DailySummaryDto> DailyInfo { get; set; } = [];
    public string SnapShotDate { get; set; } = "";
}

public class DailySummaryDto
{
    public string Line { get; set; } = "";
    public double Day { get; set; }
    public double SOP { get; set; }
    public double WorkingRatio { get; set; }
    public double Efficiency { get; set; }
}

public class LineStatusDto
{
    public string Line { get; set; } = "";
    public string Status { get; set; } = "";
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

public class JobRequest
{
    public string JobType { get; set; } = string.Empty;
    public string JobName { get; set; } = "";
    public DateTime RunTime { get; set; } = DateTime.Now;
    public int RetryCnt { get; set; }
    public string FromService { get; set; } = "CoilMonitorWeb";
    public bool NotificationRequired { get; set; }
    public string AuthTokenHash { get; set; } = string.Empty;
}

public class QueueInformationDto
{
    public int PendingCount { get; set; }
    public int CompletedCount { get; set; }
    public int FailedCount { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class DashboardTwoDto
{
    public List<ServerStatusDto> Servers { get; set; } = new();
}

public class ServerStatusDto
{
    public string Server { get; set; } = "";
    public string State { get; set; } = "";
    public DateTimeOffset HeartbeatDT { get; set; }
}
