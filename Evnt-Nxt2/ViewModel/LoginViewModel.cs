using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class LoginViewModel
    {
        [BindProperty]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }
    }
}
