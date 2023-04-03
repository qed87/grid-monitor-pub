namespace kirchnerd.EnergyMonitor.Monitoring
{
    /// <summary>
    /// Monitor service which tracks all status updates.
    /// </summary>
    public interface IEnergyMonitorService
    {
        /// <summary>
        /// Tracks the total power for the breaker panel.
        /// </summary>
        /// <param name="power">The consumption in watt of the breaker panel.</param>
        Task UpdateBreakerPanelAsync(double power);

        /// <summary>
        /// Tracks the total power for the solar panel.
        /// </summary>
        /// <param name="power">The power in watt of the solar panel.</param>
        Task UpdateSolarAsync(double power);
    }
}