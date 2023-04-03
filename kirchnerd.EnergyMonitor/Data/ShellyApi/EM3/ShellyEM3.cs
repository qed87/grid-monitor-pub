using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace kirchnerd.EnergyMonitor.Data.ShellyApi.EM3
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class ShellyEM3
    {
        [JsonConstructor]
        public ShellyEM3(
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
            Event = @event;
            Ul = ul;
            Rl = rl;
            Device = device;
            Status = status;
            OldStatus = oldStatus;
            Integrations = integrations;
            Metadata = metadata;
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
