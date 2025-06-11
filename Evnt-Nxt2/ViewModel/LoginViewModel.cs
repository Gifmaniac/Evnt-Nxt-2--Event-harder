using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class LoginViewModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
