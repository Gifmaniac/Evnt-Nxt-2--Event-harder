using System.Text.RegularExpressions;
using Evnt_Nxt_Business_.Interfaces;


namespace Evnt_Nxt_Business_
{
    public class RegisterValidator : IRegisterValidator
    {

        public List<string> ValidateAll(string email, string password, string username)
        {
            var errors = new List<string>();

            errors.AddRange(ValidateMail(email));
            errors.AddRange(ValidateUsername(username));
            errors.AddRange(ValidatePasswordCheck(password));

            return errors;
        }

        private static List<string>ValidateMail(string email)
        {
            List<string> errors = new();

            if (!Regex.IsMatch(email, @"^[\w.-]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                errors.Add("Invalid email");
            }
            return errors;
        }


        private static List<string> ValidateUsername(string username)
        {
            List<string> errors = new();

            if (username.Length < 3)
            {
                errors.Add("Username must be at least 3 characters long.");
            }


            if (username.Length > 20)
            {
                errors.Add("Username must not exceed 20 characters.");

            }

            if (!Regex.IsMatch(username, "^[a-zA-Z0-9_.]+$"))
            {
                errors.Add("Username can only contain letters, numbers, underscores, and dots.");
            }

            if (username.StartsWith(".") || username.StartsWith("_") ||
                username.EndsWith(".") || username.EndsWith("_"))
            {
                errors.Add("Username cannot start or end with a dot or underscore.");
            }

            var blockedWords = new[] { "admin", "root", "moderator", "fuck", "shit"};

            if (blockedWords.Any(word => username.ToLower().Contains(word)))
            {
                errors.Add("Username contains a restricted word.");
            }

            return errors;
        }

        private static List<string> ValidatePasswordCheck(string password)
        {
            List<string> errors = new();

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add("Password cannot be empty.");
            }

            if (password.Length < 8)
            {
                errors.Add("Password must be at least 8 characters long.");
            }

            if (!password.Any(char.IsDigit))
            {
                errors.Add("Password must contain at least one digit.");
            }

            if (!password.Any(char.IsUpper))
            {
                errors.Add("Password must contain at least one uppercase letter.");
            }

            if (!Regex.IsMatch(password, "[!@#$%^&*]"))
            {
                errors.Add("Password must contain at least one special character (!, @, #, etc.).");
            }

            return errors;
        }
    }
}
