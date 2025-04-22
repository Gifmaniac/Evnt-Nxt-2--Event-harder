using Evnt_Nxt_Business_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Evnt_Nxt2.Pages;

public class IndexModel : PageModel
{
    private readonly Service Service;

    public IndexModel(Service service)
    {
        this.Service = service;
    }

    public async Task OnGetAsync()
    {
        //try
        //{
        //    Events = await Service.GetAllEventsAsync();
        //    IsConnected = Service.CheckDatabaseConnection();
        //    ViewData["Message"] = "Database connection successful!";
        //}
        //catch (Exception ex)
        //{
        //    ViewData["Message"] = $"Connection failed: {ex.Message}";
        //    IsConnected = false;
        //}
    }

    public bool IsConnected { get; set; }

    public void OnGet()
    {
        try
        {
            Service.PerformDatabaseOperation();  // Calling the method that opens the connection
            ViewData["Message"] = "Database connection successful!";
        }
        catch (Exception ex)
        {
            ViewData["Message"] = $"Database connection failed: {ex.Message}";
        }
        IsConnected = Service.CheckDatabaseConnection();
    }
}
