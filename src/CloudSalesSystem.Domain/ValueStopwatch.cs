namespace CloudSalesSystem.Domain;

using System.Diagnostics;

public readonly struct ValueStopwatch
{
    private static readonly double s_timestampToTicks = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;

    private readonly long _startTimestamp;

    private ValueStopwatch(long startTimestamp) => _startTimestamp = startTimestamp;

    public static ValueStopwatch StartNew() => new(Stopwatch.GetTimestamp());

    public static TimeSpan GetElapsedTime(long startTimestamp, long endTimestamp)
    {
        long timestampDelta = endTimestamp - startTimestamp;
        long ticks = (long)(s_timestampToTicks * timestampDelta);
        return new TimeSpan(ticks);
    }

    public TimeSpan GetElapsedTime() => GetElapsedTime(_startTimestamp, Stopwatch.GetTimestamp());
}