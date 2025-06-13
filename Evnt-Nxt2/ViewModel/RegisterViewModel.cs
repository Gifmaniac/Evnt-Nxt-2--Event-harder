using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class RegisterViewModel
    {
<<<<<<< Updated upstream
        [Required]
        public string Email { get; set; }

        [Required]
=======
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
        public string Email { get; set; }

        [BindProperty] [Required()]
>>>>>>> Stashed changes
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
