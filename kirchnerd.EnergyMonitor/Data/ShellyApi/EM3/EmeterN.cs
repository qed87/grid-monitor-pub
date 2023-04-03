using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class EmeterN
{
    [JsonConstructor]
    public EmeterN(
        int current,
        double ixsum,
        bool mismatch,
        bool isValid
    )
    {
        Current = current;
        Ixsum = ixsum;
        Mismatch = mismatch;
        IsValid = isValid;
    }

    [JsonProperty("current")]
    public int Current { get; }

    [JsonProperty("ixsum")]
    public double Ixsum { get; }

    [JsonProperty("mismatch")]
    public bool Mismatch { get; }

    [JsonProperty("is_valid")]
    public bool IsValid { get; }
}