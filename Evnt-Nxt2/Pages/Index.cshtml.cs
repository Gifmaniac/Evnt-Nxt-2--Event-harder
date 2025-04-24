using Evnt_Nxt_Business_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Evnt_Nxt2.Pages;

public class IndexModel : PageModel
{
    public bool IsConnected { get; set; }

    public void OnGet()
    {

    }
}
