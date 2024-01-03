using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MyMessagePro.DAL.Context;
using MyMessagePro.DAL.Entities;
using MyMessagePro.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>
	().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();
builder.Services.AddSession(options =>
{
    // Session ayarlar�n� burada yapabilirsiniz
    // �rne�in, timeout s�resini belirleyebilirsiniz
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
	var policy=new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
