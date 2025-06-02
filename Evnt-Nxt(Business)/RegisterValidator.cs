using System.Text.RegularExpressions;


namespace Evnt_Nxt_Business_
{
    public class RegisterValidator
    {

        public List<string> ValidateAll(string email, string password, string username)
        {
            var errors = new List<string>();

            errors.AddRange(IsMailValidated(email));
            errors.AddRange(ValidateUsername(username));
            errors.AddRange(ValidatePassWordCheck(password));

            return errors;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                var newMail = new System.Net.Mail.MailAddress(email);
                return newMail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private List<string> IsMailValidated(string email)
        {
            List<string> errors = new();

            if (!ValidateEmail(email))
            {
                errors.Add("Invalid email address.");
            }
            return errors;
        }


        private List<string> ValidateUsername(string username)
        {
            List<string> errors = new();

            if (username.Length < 3)
                errors.Add("Username must be at least 3 characters long.");

            if (username.Length > 20)
                errors.Add("Username must not exceed 20 characters.");

            if (!Regex.IsMatch(username, "^[a-zA-Z0-9_.]+$"))
                errors.Add("Username can only contain letters, numbers, underscores, and dots.");

            if (username.StartsWith(".") || username.StartsWith("_") ||
                username.EndsWith(".") || username.EndsWith("_"))
            {
                errors.Add("Username cannot start or end with a dot or underscore.");
            }

            var blockedWords = new[] { "admin", "root", "moderator", "fuck", "shit"};

            if (blockedWords.Any(word => username.ToLower().Contains(word)))
                errors.Add("Username contains a restricted word.");

            return errors;
        }

        private List<string> ValidatePassWordCheck(string password)
        {
            List<string> errors = new();

            if (string.IsNullOrWhiteSpace(password))
                errors.Add("Password cannot be empty.");

            if (password.Length < 8)
                errors.Add("Password must be at least 8 characters long.");

            if (!password.Any(char.IsDigit))
                errors.Add("Password must contain at least one digit.");

            if (!password.Any(char.IsUpper))
                errors.Add("Password must contain at least one uppercase letter.");

            if (!Regex.IsMatch(password, "[!@#$%^&*]"))
                errors.Add("Password must contain at least one special character (!, @, #, etc.).");


            return errors;
        }
    }
}
