using kirchnerd.EnergyMonitor.Monitoring;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<ITokenRefreshService, TokenRefreshService>();
builder.Services.AddSingleton<IEnergyMonitorService, EnergyMonitorService>();
// Background service which consumes status updates from the shelly cloud
builder.Services.AddHostedService<EnergyMonitorHostingService>();

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// https://github.com/prometheus-net/prometheus-net#aspnet-core-http-request-metrics
app.UseRouting();
app.UseHttpMetrics(options =>
{
    options.AddCustomLabel("host", context => context.Request.Host.Host);
});

app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();
});

app.Run();