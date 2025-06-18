using Evnt_Nxt_Business_.Services;
using Evnt_Nxt_Business_;
using EvntNxtDTO;

namespace TestProject1
{
    public class RegisterServiceValidatorTest
    {
        [Fact]
        public void VerifyRegister_WithInvalidPassword_ReturnsValidationError()
        {
            // Arrange
            var repository = new InMemoryRegisterRepository(); // lightweight test repo
            var validator = new RegisterValidator();           // The real validator
            var hasher = new PasswordHasher();                 // The real hasher

            var service = new RegisterService(repository, hasher, validator);

            var newUser = new RegisterDTO
            {
                Email = "w.vd.b@test.nl",
                UserName = "Willempieeeee",
                Password = "Test12!"
            };

            // Act
            var (isValid, errors) = service.VerifyRegister(newUser);

            // Assert
            Assert.False(isValid);
            Assert.Contains(errors, error => error.ToLower().Contains("password"));
        }

        [Fact]
        public void VerifyRegister_WithValidInput_ReturnsSuccess()
        {
            // Arrange
            var repository = new InMemoryRegisterRepository();  // lightweight test repo
            var validator = new RegisterValidator();            // The real validator
            var hasher = new PasswordHasher();                  // The real hasher

            var service = new RegisterService(repository, hasher, validator);

            var newUser = new RegisterDTO
            {
                Email = "w.vd.b@hotmail.nl",
                UserName = "validUser",
                Password = "StrongPassword123!"
            };

            // Act
            var (isValid, errors) = service.VerifyRegister(newUser);

            // Assert
            Assert.True(isValid);
            Assert.Empty(errors);
        }

        [Fact]
        public void VerifyRegister_WithDuplicatedMail_ReturnsValidationError()
        {
            // Arrange
            var repository = new InMemoryRegisterRepository(); // lightweight test
            var validator = new RegisterValidator();           // The real validator
            var hasher = new PasswordHasher();                 // The real hasher

            var service = new RegisterService(repository, hasher, validator);

            var newUser = new RegisterDTO
            {
                Email = "w.vd.b@Live.nl",
                UserName = "Willempieeeee",
                Password = "Test123!"
            };

            // Act
            var (isValid, errors) = service.VerifyRegister(newUser);

            // Assert
            Assert.False(isValid);
            Assert.Contains(errors, error => error.Contains("email"));
        }

        [Fact]
        public void VerifyRegister_WithDuplicatedUsername_ReturnsValidationError()
        {
            // Arrange
            var repository = new InMemoryRegisterRepository(); // lightweight test repo I don't want to fill my database with test data. 
            var validator = new RegisterValidator();           // The real validator
            var hasher = new PasswordHasher();                 // The real hasher

            var service = new RegisterService(repository, hasher, validator);

            var newUser = new RegisterDTO
            {
                Email = "w.vd.b@Live.nl",
                UserName = "HELLOWORLD",
                Password = "Test123!"
            };

            // Act
            var (isValid, errors) = service.VerifyRegister(newUser);

            // Assert
            Assert.False(isValid);
            Assert.Contains(errors, error => error.Contains("username"));
        }
    }
}
