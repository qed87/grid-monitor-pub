using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

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