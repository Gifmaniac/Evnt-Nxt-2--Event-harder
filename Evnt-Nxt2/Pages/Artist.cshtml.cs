using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Evnt_Nxt_Business_;

namespace Evnt_Nxt2.Pages
{

    public class ArtistModel : PageModel
    {
        private readonly Service Service;

        public ArtistModel(Service service)
        {
            this.Service = service;
        }

        public void OnGet()
        {
        }
    }
}
