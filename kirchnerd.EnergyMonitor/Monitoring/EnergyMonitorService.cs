using Prometheus;

namespace kirchnerd.EnergyMonitor.Monitoring
{
    public class EnergyMonitorService : IEnergyMonitorService
    {
        private static readonly Gauge InfeedGauge = Metrics
            .CreateGauge("infeed_energy", "Infeeded power from solar production in Watt.");
        private static readonly Gauge EnergyUsedGauge = Metrics
            .CreateGauge("energy_used", "Cost-relevant power consumed by the household in Watt.");
        private static readonly Gauge EnergyTotalUsedGauge = Metrics
            .CreateGauge("energy_total_used", "Actual power consumed by the household in Watt.");
        private static readonly Gauge SolarProducedGauge = Metrics
            .CreateGauge("solar_produced", "Solar power produced by panels in Watt.");
        private static readonly Gauge SolarUsedGauge = Metrics
            .CreateGauge("solar_used", "Cost-relevant usage of solar power by panels in Watt.");

        /// <inheritdoc />
        public Task UpdateBreakerPanelAsync(double power)
        {
            ReportMetrics(power, MetricType.Breaker);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UpdateSolarAsync(double power)
        {
            ReportMetrics(power, MetricType.Solar);
            return Task.CompletedTask;
        }

        private static void ReportMetrics(double power, MetricType metricType)
        {
            switch (metricType)
            {
                case MetricType.Solar:
                    SolarProducedGauge.Set(Math.Abs(power));
                    break;
                case MetricType.Breaker:
                    if (power >= 0)
                    {
                        InfeedGauge.Set(0.0);
                        EnergyUsedGauge.Set(power);
                    }
                    else
                    {
                        InfeedGauge.Set(Math.Abs(power));
                        EnergyUsedGauge.Set(0.0);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(metricType), metricType, null);
            }
            SolarUsedGauge.Set(SolarProducedGauge.Value - InfeedGauge.Value);
            EnergyTotalUsedGauge.Set(EnergyUsedGauge.Value + SolarProducedGauge.Value);
        }
    }
}
