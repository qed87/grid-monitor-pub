using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class ActionsStats
{
    [Newtonsoft.Json.JsonConstructor]
    public ActionsStats(
        int skipped
    )
    {
        Skipped = skipped;
    }

    [JsonProperty("skipped")]
    public int Skipped { get; }
}