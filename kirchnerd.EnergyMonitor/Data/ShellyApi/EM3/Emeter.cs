using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Emeter
{
    [JsonConstructor]
    public Emeter(
        double power,
        double pf,
        double current,
        double voltage,
        bool isValid,
        double total,
        double totalReturned
    )
    {
        Power = power;
        Pf = pf;
        Current = current;
        Voltage = voltage;
        IsValid = isValid;
        Total = total;
        TotalReturned = totalReturned;
    }

    [JsonProperty("power")]
    public double Power { get; }

    [JsonProperty("pf")]
    public double Pf { get; }

    [JsonProperty("current")]
    public double Current { get; }

    [JsonProperty("voltage")]
    public double Voltage { get; }

    [JsonProperty("is_valid")]
    public bool IsValid { get; }

    [JsonProperty("total")]
    public double Total { get; }

    [JsonProperty("total_returned")]
    public double TotalReturned { get; }
}