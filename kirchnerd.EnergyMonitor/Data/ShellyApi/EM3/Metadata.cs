using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Metadata
{
    [JsonConstructor]
    public Metadata(
        string name,
        int rid,
        string purpose,
        bool eld
    )
    {
        Name = name;
        Rid = rid;
        Purpose = purpose;
        Eld = eld;
    }

    [JsonProperty("name")]
    public string Name { get; }
    
    [JsonProperty("rid")]
    public int Rid { get; }
    
    [JsonProperty("purpose")]
    public string Purpose { get; }
    
    [JsonProperty("eld")]
    public bool Eld { get; }
}