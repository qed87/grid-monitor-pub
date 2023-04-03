using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class WifiSta
{
    [JsonConstructor]
    public WifiSta(
        bool connected,
        string ssid,
        string ip,
        int rssi
    )
    {
        Connected = connected;
        Ssid = ssid;
        Ip = ip;
        Rssi = rssi;
    }

    [JsonProperty("connected")]
    public bool Connected { get; }
    
    [JsonProperty("ssid")]
    public string Ssid { get; }
    
    [JsonProperty("ip")]
    public string Ip { get; }
    
    [JsonProperty("rssi")]
    public int Rssi { get; }
}