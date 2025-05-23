using Evnt_Nxt_Business_;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<GenreRepository>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<EventTicketRepository>();
builder.Services.AddScoped<IEventTicketService, EventTicketService>();


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
