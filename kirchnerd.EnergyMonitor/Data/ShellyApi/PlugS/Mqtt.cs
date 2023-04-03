using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Mqtt
{
    [JsonConstructor]
    public Mqtt(
        bool connected
    )
    {
        Connected = connected;
    }

    [JsonProperty("connected")]
    public bool Connected { get; }
}