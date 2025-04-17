using Evnt_Nxt_Business_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Evnt_Nxt2.Pages;

public class IndexModel : PageModel
{
    private readonly Service Service;

    public IndexModel(Service service)
    {
        this.Service = service;
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
