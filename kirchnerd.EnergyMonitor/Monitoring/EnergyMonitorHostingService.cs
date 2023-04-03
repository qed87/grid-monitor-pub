using System.Net.WebSockets;
using kirchnerd.EnergyMonitor.Data.ShellyApi.EM3;
using kirchnerd.EnergyMonitor.Data.ShellyApi.PlugS;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kirchnerd.EnergyMonitor.Monitoring
{
    /// <summary>
    /// Background service which connects to the shelly cloud and handles status updates.
    /// </summary>
    public class EnergyMonitorHostingService : BackgroundService
    {
        private readonly ILogger<EnergyMonitorHostingService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITokenRefreshService _tokenRefreshService;
        private readonly IEnergyMonitorService _energyMonitorService;
        private readonly string[] _includedDevices;

        public EnergyMonitorHostingService(
            ILogger<EnergyMonitorHostingService> logger,
            IConfiguration configuration,
            ITokenRefreshService tokenRefreshService,
            IEnergyMonitorService energyMonitorService)
        {
            ArgumentNullException.ThrowIfNull(logger, nameof(logger));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
            ArgumentNullException.ThrowIfNull(tokenRefreshService, nameof(tokenRefreshService));
            ArgumentNullException.ThrowIfNull(energyMonitorService, nameof(energyMonitorService));
            _logger = logger;
            _configuration = configuration;
            var devices = new List<string>();
            _configuration.GetSection("IncludedDevices").Bind(devices);
            _includedDevices = devices.ToArray();
            _tokenRefreshService = tokenRefreshService;
            _energyMonitorService = energyMonitorService;
        }

        /// <inheritdoc />
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var accessToken = _tokenRefreshService.GetAccessToken();
                try
                {
                    _logger.LogInformation("(Re-)Connect to shelly.cloud to receive status updates.");
                    await ConnectAsync(accessToken, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private async Task ConnectAsync(string accessToken, CancellationToken cancellationToken)
        {
            var monitoringSocketUri = _configuration.GetConnectionString("Websocket");
            var uriBuilder = new UriBuilder(monitoringSocketUri)
            {
                Path = "/shelly/wss/hk_sock"
            };
            var qb = new QueryBuilder { { "t", accessToken } };
            uriBuilder.Query = qb.ToString();
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(uriBuilder.Uri, cancellationToken);
            List<byte> octets = new();
            do
            {
                var buffer = new byte[1024];
                var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                octets.AddRange(buffer[0..result.Count]);
                if (!result.EndOfMessage) continue;
                var msg = System.Text.Encoding.UTF8.GetString(octets.ToArray());
                var jObj = JObject.Parse(msg);
                var deviceCode = jObj["device"]["code"].Value<string>();
                dynamic? eventData = null;
                switch (deviceCode)
                {
                    case "SHEM-3":
                        _logger.LogDebug("Received status update for 'SHEM-3'.");
                        eventData = JsonConvert.DeserializeObject<ShellyEM3>(msg);
                        break;
                    case "SHPLG-S":
                        _logger.LogDebug("Received status update for 'SHPLG-S'.");
                        eventData = JsonConvert.DeserializeObject<ShellyPlugS>(msg);
                        break;
                }

                if (eventData is null)
                {
                    _logger.LogWarning($"Message could not be processed: {msg}");
                    continue;
                }

                await HandleAsync(eventData);
                octets.Clear();
            }
            while (!cancellationToken.IsCancellationRequested);
        }

        private async Task HandleAsync(ShellyPlugS plug)
        {
            if (!_includedDevices.Contains(plug.Status.Mac))
            {
                // we only listen to specific plugs.
                return;
            }

            await _energyMonitorService.UpdateSolarAsync(plug.Status.Meters[0].Power);
        }

        private async Task HandleAsync(ShellyEM3 meter)
        {
            await _energyMonitorService.UpdateBreakerPanelAsync(meter.Status.TotalPower);
        }
    }
}
