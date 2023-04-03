using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Relay
{
    [JsonConstructor]
    public Relay(
        bool ison,
        bool hasTimer,
        int timerStarted,
        int timerDuration,
        int timerRemaining,
        bool overpower,
        bool isValid,
        string source
    )
    {
        Ison = ison;
        HasTimer = hasTimer;
        TimerStarted = timerStarted;
        TimerDuration = timerDuration;
        TimerRemaining = timerRemaining;
        Overpower = overpower;
        IsValid = isValid;
        Source = source;
    }

    [JsonProperty("ison")]
    public bool Ison { get; }

    [JsonProperty("has_timer")]
    public bool HasTimer { get; }

    [JsonProperty("timer_started")]
    public int TimerStarted { get; }

    [JsonProperty("timer_duration")]
    public int TimerDuration { get; }

    [JsonProperty("timer_remaining")]
    public int TimerRemaining { get; }

    [JsonProperty("overpower")]
    public bool Overpower { get; }

    [JsonProperty("is_valid")]
    public bool IsValid { get; }

    [JsonProperty("source")]
    public string Source { get; }
}