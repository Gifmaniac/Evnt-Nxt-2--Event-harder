using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName {get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required] 
        public DateOnly BirthDay { get; set; }

    }
}
