using Evnt_Nxt_Business_;
using Evnt_Nxt_Business_.DomainClass;
using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_DAL_;
using Evnt_Nxt_DAL_.Interfaces;
using Evnt_Nxt_DAL_.Repository;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Repositories
builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<GenreRepository>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<EventTicketRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Services
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IEventTicketService, EventTicketService>();
builder.Services.AddScoped<RegisterService>();

// Utilities
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<RegisterValidator>();


builder.Services.AddRazorPages();
builder.Services.AddSession();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSession();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
