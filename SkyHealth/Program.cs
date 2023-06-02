using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using SkyHealth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("sample");

builder.Services.AddHealthChecksUI(options =>
{
    options.AddHealthCheckEndpoint("main", "/health");
    options.SetEvaluationTimeInSeconds(1);
})
    .AddInMemoryStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
