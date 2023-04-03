using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class ShellyPlugS
    {
        [JsonConstructor]
        public ShellyPlugS(
            string @event,
            List<int> ul,
            List<string> rl,
            Device device,
            Status status,
            OldStatus oldStatus,
            List<object> integrations,
            List<Metadata> metadata
        )
        {
            this.Event = @event;
            this.Ul = ul;
            this.Rl = rl;
            this.Device = device;
            this.Status = status;
            this.OldStatus = oldStatus;
            this.Integrations = integrations;
            this.Metadata = metadata;
        }

        [JsonProperty("event")]
        public string Event { get; }
        
        [JsonProperty("ul")]
        public IReadOnlyList<int> Ul { get; }
        
        [JsonProperty("rl")]
        public IReadOnlyList<string> Rl { get; }
        
        [JsonProperty("device")]
        public Device Device { get; }
        
        [JsonProperty("status")]
        public Status Status { get; }
        
        [JsonProperty("oldStatus")]
        public OldStatus OldStatus { get; }
        
        [JsonProperty("integrations")]
        public IReadOnlyList<object> Integrations { get; }
        
        [JsonProperty("metadata")]
        public IReadOnlyList<Metadata> Metadata { get; }
    }
}