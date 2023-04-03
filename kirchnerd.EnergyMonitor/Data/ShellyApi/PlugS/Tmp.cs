using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Tmp
{
    [JsonConstructor]
    public Tmp(
        double tc,
        double tf,
        bool isValid
    )
    {
        Tc = tc;
        Tf = tf;
        IsValid = isValid;
    }

    [JsonProperty("tC")]
    public double Tc { get; }
    
    [JsonProperty("tF")]
    public double Tf { get; }
    
    [JsonProperty("is_valid")]
    public bool IsValid { get; }
}