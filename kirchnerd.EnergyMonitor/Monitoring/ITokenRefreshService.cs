namespace kirchnerd.EnergyMonitor.Monitoring
{
    /// <summary>
    /// Token refresh service.
    /// </summary>
    public interface ITokenRefreshService
    {
        /// <summary>
        /// Gets the current access token.
        /// </summary>
        /// <returns>Returns the current access token.</returns>
        string GetAccessToken();

        /// <summary>
        /// Gets the current refresh token.
        /// </summary>
        /// <returns>Returns the current refresh token.</returns>
        string GetRefreshToken();

    }
}