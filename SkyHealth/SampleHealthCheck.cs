using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SkyHealth
{
    public class SampleHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(DateTimeOffset.Now.Ticks % 3 == 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy());
        }
    }
}
