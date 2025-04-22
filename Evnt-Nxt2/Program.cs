using Evnt_Nxt_Business_;
using Evnt_Nxt_DAL_;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Register DatabaseContext with DI
//builder.Services.AddSingleton<DatabaseContext>(provider =>
//    new DatabaseContext(builder.Configuration));

//// Register the Service with DI
//builder.Services.AddSingleton<Service>();

builder.Services.AddRazorPages();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
