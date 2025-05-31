using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Evnt_Nxt2.ViewModel
{
    public class RegisterViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }

    }
}
