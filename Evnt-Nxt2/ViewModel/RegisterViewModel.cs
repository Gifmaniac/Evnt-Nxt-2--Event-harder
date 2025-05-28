using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class RegisterViewModel
    {
        [BindProperty] [Required]
        public string Email { get; set; }

        [BindProperty] [Required]
        public string Password { get; set; }

        [BindProperty] [Required]
        public string UserName {get; set; }

        [BindProperty] [Required]
        public string FirstName { get; set; }

        [BindProperty] [Required]
        public string LastName { get; set; }

        [BindProperty] [Required] 
        public DateOnly BirthDay { get; set; }

    }
}
