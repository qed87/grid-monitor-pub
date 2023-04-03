using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;

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
        List<Emeter> emeters,
        double totalPower,
        EmeterN emeterN,
        bool fsMounted,
        int vData,
        int ctCalst,
        Update update,
        int ramTotal,
        int ramFree,
        int fsSize,
        int fsFree,
        int uptime
    )
    {
        WifiSta = wifiSta;
        Cloud = cloud;
        Mqtt = mqtt;
        Time = time;
        Unixtime = unixtime;
        Serial = serial;
        HasUpdate = hasUpdate;
        Mac = mac;
        CfgChangedCnt = cfgChangedCnt;
        ActionsStats = actionsStats;
        Relays = relays;
        Emeters = emeters;
        TotalPower = totalPower;
        EmeterN = emeterN;
        FsMounted = fsMounted;
        VData = vData;
        CtCalst = ctCalst;
        Update = update;
        RamTotal = ramTotal;
        RamFree = ramFree;
        FsSize = fsSize;
        FsFree = fsFree;
        Uptime = uptime;
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
    
    [JsonProperty("emeters")]
    public IReadOnlyList<Emeter> Emeters { get; }
    
    [JsonProperty("total_power")]
    public double TotalPower { get; }
    
    [JsonProperty("emeter_n")]
    public EmeterN EmeterN { get; }
    
    [JsonProperty("fs_mounted")]
    public bool FsMounted { get; }
    
    [JsonProperty("v_data")]
    public int VData { get; }
    
    [JsonProperty("ct_calst")]
    public int CtCalst { get; }
    
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