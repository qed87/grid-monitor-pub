using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class Status
{
    [JsonConstructor]
    public Status(
        WifiSta wifiSta,
        Cloud cloud,
        Mqtt mqtt,
        string time,
        int unixtime,
        int serial,
        bool hasUpdate,
        string mac,
        int cfgChangedCnt,
        ActionsStats actionsStats,
        List<Relay> relays,
        List<Meter> meters,
        double temperature,
        bool overtemperature,
        Tmp tmp,
        Update update,
        int ramTotal,
        int ramFree,
        int fsSize,
        int fsFree,
        int uptime
    )
    {
        this.WifiSta = wifiSta;
        this.Cloud = cloud;
        this.Mqtt = mqtt;
        this.Time = time;
        this.Unixtime = unixtime;
        this.Serial = serial;
        this.HasUpdate = hasUpdate;
        this.Mac = mac;
        this.CfgChangedCnt = cfgChangedCnt;
        this.ActionsStats = actionsStats;
        this.Relays = relays;
        this.Meters = meters;
        this.Temperature = temperature;
        this.Overtemperature = overtemperature;
        this.Tmp = tmp;
        this.Update = update;
        this.RamTotal = ramTotal;
        this.RamFree = ramFree;
        this.FsSize = fsSize;
        this.FsFree = fsFree;
        this.Uptime = uptime;
    }

    [JsonProperty("wifi_sta")]
    public WifiSta WifiSta { get; }
    
    [JsonProperty("cloud")]
    public Cloud Cloud { get; }
    
    [JsonProperty("mqtt")]
    public Mqtt Mqtt { get; }
    
    [JsonProperty("time")]
    public string Time { get; }
    
    [JsonProperty("unixtime")]
    public int Unixtime { get; }
    
    [JsonProperty("serial")]
    public int Serial { get; }
    
    [JsonProperty("has_update")]
    public bool HasUpdate { get; }
    
    [JsonProperty("mac")]
    public string Mac { get; }
    
    [JsonProperty("cfg_changed_cnt")]
    public int CfgChangedCnt { get; }
    
    [JsonProperty("actions_stats")]
    public ActionsStats ActionsStats { get; }
    
    [JsonProperty("relays")]
    public IReadOnlyList<Relay> Relays { get; }
    
    [JsonProperty("meters")]
    public IReadOnlyList<Meter> Meters { get; }
    
    [JsonProperty("temperature")]
    public double Temperature { get; }
    
    [JsonProperty("overtemperature")]
    public bool Overtemperature { get; }
    
    [JsonProperty("tmp")]
    public Tmp Tmp { get; }
    
    [JsonProperty("update")]
    public Update Update { get; }
    
    [JsonProperty("ram_total")]
    public int RamTotal { get; }
    
    [JsonProperty("ram_free")]
    public int RamFree { get; }
    
    [JsonProperty("fs_size")]
    public int FsSize { get; }
    
    [JsonProperty("fs_free")]
    public int FsFree { get; }
    
    [JsonProperty("uptime")]
    public int Uptime { get; }
}