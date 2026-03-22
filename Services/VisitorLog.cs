using System.Collections.Concurrent;

namespace DnsProxyPoc.Services;

public record VisitorEntry(string Time, string Path, string Method, string UserAgent, bool IsCrawler, string? Ip);

public sealed class VisitorLog
{
    private readonly ConcurrentQueue<VisitorEntry> _entries = new();

    public void Log(VisitorEntry entry)
    {
        _entries.Enqueue(entry);
        while (_entries.Count > 50) _entries.TryDequeue(out _);
    }

    public IReadOnlyCollection<VisitorEntry> GetEntries() => _entries.ToArray();
}
