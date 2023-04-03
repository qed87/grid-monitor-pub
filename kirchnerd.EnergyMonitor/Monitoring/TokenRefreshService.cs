using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using kirchnerd.EnergyMonitor.Exceptions;
using Microsoft.AspNetCore.Http.Extensions;

namespace kirchnerd.EnergyMonitor.Monitoring
{
    /// <summary>
    /// Implementation of the token refresh service.
    /// </summary>
    public class TokenRefreshService : ITokenRefreshService
    {
        private readonly HttpClient _httpClient;
        private readonly ReaderWriterLockSlim _rwLock = new();
        private readonly Uri _authEndpoint;
        private string _accessToken;
        private string _refreshToken;
        private readonly string _clientId;

        public TokenRefreshService(HttpClient httpClient, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(httpClient, nameof(httpClient));
            ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
            _httpClient = httpClient;
            _clientId = configuration.GetValue<string>("Auth:ClientId");
            _authEndpoint = new Uri(configuration.GetConnectionString("Identity"), UriKind.Absolute);
            // hint: normally retrieved from environment variables or command line arguments
            _accessToken = configuration.GetValue<string>("ACCESS_TOKEN");
            _refreshToken = configuration.GetValue<string>("REFRESH_TOKEN");
            var expiresIn = OnElapsedInternal(null);
            var refreshTimer = new Timer(OnElapsed);
            var period = (int)expiresIn.TotalMilliseconds / 2;
            refreshTimer.Change(period, period);
        }

        /// <inheritdoc />
        public string GetAccessToken()
        {
            try
            {
                _rwLock.EnterReadLock();
                return _accessToken;
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        /// <inheritdoc />
        public string GetRefreshToken()
        {
            try
            {
                _rwLock.EnterReadLock();
                return _refreshToken;
            }
            finally
            {
                _rwLock.ExitReadLock();
            }
        }

        private void OnElapsed(object? state)
        {
            OnElapsedInternal(state);
        }

        private TimeSpan OnElapsedInternal(object? state)
        {
            var uriBuilder = new UriBuilder(_authEndpoint);
            var queryBuilder = new QueryBuilder
            {
                { "client_id", _clientId },
                { "grant_type", "refresh_token" },
                { "refresh_token", GetRefreshToken() }
            };
            uriBuilder.Query = queryBuilder.ToString();
            var req = new HttpRequestMessage(
                HttpMethod.Post,
                uriBuilder.ToString());
            req.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("*/*"));
            req.Headers.UserAgent.Add(ProductInfoHeaderValue.Parse("shelly-diy"));
            var res = _httpClient.Send(req);
            using var stream = res.Content.ReadAsStream();
            using var streamReader = new StreamReader(stream, true);
            var token = streamReader.ReadToEnd();
            var jNode = JsonNode.Parse(token);
            if (jNode is null) throw new InvalidJsonWebTokenException();
            var jObj = jNode.AsObject();
            if (!jObj.ContainsKey("access_token")) throw new InvalidJsonWebTokenException("access_token");
            if (!jObj.ContainsKey("refresh_token")) throw new InvalidJsonWebTokenException("refresh_token");
            if (!jObj.ContainsKey("expires_in")) throw new InvalidJsonWebTokenException("expires_in");
            var accessToken = jObj["access_token"]!.GetValue<string>();
            var refreshToken = jNode["refresh_token"]!.GetValue<string>();
            var expiresInSeconds = jNode["expires_in"]!.GetValue<int>();
            try
            {
                _rwLock.EnterWriteLock();
                _accessToken = accessToken;
                _refreshToken = refreshToken;
                return TimeSpan.FromSeconds(expiresInSeconds);
            }
            finally
            {
                _rwLock.ExitWriteLock();
            }
        }
    }
}
