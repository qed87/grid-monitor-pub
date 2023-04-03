using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Meter
{
    [JsonConstructor]
    public Meter(
        double power,
        int overpower,
        bool isValid,
        int timestamp,
        List<double> counters,
        int total
    )
    {
        Power = power;
        Overpower = overpower;
        IsValid = isValid;
        Timestamp = timestamp;
        Counters = counters;
        Total = total;
    }

    [JsonProperty("power")]
    public double Power { get; }
    
    [JsonProperty("overpower")]
    public int Overpower { get; }
    
    [JsonProperty("is_valid")]
    public bool IsValid { get; }
    
    [JsonProperty("timestamp")]
    public int Timestamp { get; }
    
    [JsonProperty("counters")]
    public IReadOnlyList<double> Counters { get; }
    
    [JsonProperty("total")]
    public int Total { get; }
}