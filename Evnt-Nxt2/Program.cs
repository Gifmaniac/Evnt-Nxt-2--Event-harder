using Evnt_Nxt_Business_;
using Evnt_Nxt_Business_.Managers;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<ArtistGenreRepository>();
builder.Services.AddScoped<ArtistManager>();
builder.Services.AddScoped<ArtistGenreManager>();


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
