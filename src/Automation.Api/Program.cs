using System.Runtime.InteropServices;
using Automation.Domain.Entities;
using Automation.Api.Middleware;
using Automation.Domain.Interfaces;
using Automation.Infrastructure.Services;
using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<ITaskValidator, TaskValidator>();
builder.Services.AddTransient<ITaskExecutor, BasicTaskExecutor>();
builder.Services.Configure<AutomationOptions>(builder.Configuration.GetSection("Automation"));
builder.Services.AddTransient<IEmailJob, EmailJob>();
builder.Services.AddHostedService<TaskWorker>();

builder.Services.AddHangfire(ConfigureAwaitOptions =>
    ConfigureAwaitOptions.UseSqlServerStorage(
        builder.Configuration.GetConnectionString("Hangfire")));

builder.Services.AddHangfireServer();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHangfireDashboard();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();