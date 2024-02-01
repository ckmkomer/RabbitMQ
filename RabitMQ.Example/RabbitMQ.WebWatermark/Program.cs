using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.WebWatermark.BackgroundServices;
using RabbitMQ.WebWatermark.Data;
using RabbitMQ.WebWatermark.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(sp => new ConnectionFactory()
{
	Uri = new Uri("amqps://iclowame:LW_624OMO9yvqmcG6-bnG25vSHI3m0a0@toad.rmq.cloudamqp.com/iclowame"),DispatchConsumersAsync=true
});

builder.Services.AddSingleton<RabbitMQClientService>();
builder.Services.AddSingleton<RabbitMQPublisher>();


builder.Services.AddDbContext<Context>(option =>
{
	option.UseInMemoryDatabase(databaseName: "db");
});

builder.Services.AddHostedService<ImageWatermarkProcessBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
