using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class ActionsStats
{
    [JsonConstructor]
    public ActionsStats(
        int skipped
    )
    {
        Skipped = skipped;
    }

    [JsonProperty("skipped")]
    public int Skipped { get; }
}