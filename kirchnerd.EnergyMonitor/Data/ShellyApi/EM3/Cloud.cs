using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Cloud
{
    [JsonConstructor]
    public Cloud(
        bool enabled,
        bool connected
    )
    {
        Enabled = enabled;
        Connected = connected;
    }

    [JsonProperty("enabled")]
    public bool Enabled { get; }
    
    
    [JsonProperty("connected")]
    public bool Connected { get; }
    
}