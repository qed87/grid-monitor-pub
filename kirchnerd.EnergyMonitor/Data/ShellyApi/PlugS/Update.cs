using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Update
{
    [JsonConstructor]
    public Update(
        string status,
        bool hasUpdate,
        string newVersion,
        string oldVersion
    )
    {
        Status = status;
        HasUpdate = hasUpdate;
        NewVersion = newVersion;
        OldVersion = oldVersion;
    }

    [JsonProperty("status")]
    public string Status { get; }
    
    [JsonProperty("has_update")]
    public bool HasUpdate { get; }
    
    [JsonProperty("new_version")]
    public string NewVersion { get; }
    
    [JsonProperty("old_version")]
    public string OldVersion { get; }
}