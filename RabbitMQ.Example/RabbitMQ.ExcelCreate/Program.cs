using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.ExcelCreate.Data;
using System;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DbCon");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityRole, IdentityUser>(opt =>
{

	opt.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<Context>();
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton(sp => new ConnectionFactory()
{
	Uri = new Uri("amqps://iclowame:LW_624OMO9yvqmcG6-bnG25vSHI3m0a0@toad.rmq.cloudamqp.com/iclowame")
});
builder.Services.AddSignalR();

var app = builder.Build();


using (var scope = app.Services.CreateScope())

{

	var services = scope.ServiceProvider;


	var appDbContext = services.GetRequiredService<Context>();


	var userManager = services.GetRequiredService<UserManager<IdentityUser>>();


	await appDbContext.Database.MigrateAsync();


	if (!appDbContext.Users.Any())

	{

		await userManager.CreateAsync(new IdentityUser { UserName = "deneme", Email = "deneme@outlook.com" }, "Password12*");

		await userManager.CreateAsync(new IdentityUser { UserName = "deneme2", Email = "deneme2@outlook.com" }, "Password12*");

	}

}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
