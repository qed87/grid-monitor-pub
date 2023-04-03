using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Device
{
    [JsonConstructor]
    public Device(
        int id,
        string type,
        string code,
        string mode,
        bool sleeps,
        double lat,
        double lng,
        string gen
    )
    {
        Id = id;
        Type = type;
        Code = code;
        Mode = mode;
        Sleeps = sleeps;
        Lat = lat;
        Lng = lng;
        Gen = gen;
    }

    [JsonProperty("id")]
    public int Id { get; }
    
    [JsonProperty("type")]
    public string Type { get; }
    
    [JsonProperty("code")]
    public string Code { get; }
    
    [JsonProperty("mode")]
    public string Mode { get; }
    
    [JsonProperty("sleeps")]
    public bool Sleeps { get; }
    
    [JsonProperty("lat")]
    public double Lat { get; }
    
    [JsonProperty("lng")]
    public double Lng { get; }
    
    [JsonProperty("gen")]
    public string Gen { get; }
}