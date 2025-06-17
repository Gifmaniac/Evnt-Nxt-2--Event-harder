using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using EvntNxtDTO;
using Moq;
using Xunit;

public class TicketServiceTests
{
    [Fact]
    public void VerifyRegister_WithValidInput_DoesNotThrow()
    {
        // Arrange
        var mockRepo = new Mock<IRegisterRepository>();
        var mockHasher = new Mock<IPasswordHasher>();
        var mockValidator = new Mock<IRegisterValidator>();
        var service = new RegisterService(mockRepo.Object, mockHasher.Object, mockValidator.Object);

        var newUser = new RegisterDTO
        {
            Email = "test@example.com",
            UserName = "validUser",
            Password = "StrongPassword1!"
        };

        mockRepo
            .Setup(registerRepo => registerRepo.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
            .Returns(false); // user does NOT exist

        mockValidator
            .Setup(validator => validator.ValidateAll(newUser.Email, newUser.Password, newUser.UserName))
            .Returns(new List<string>()); // Returns NO exceptions

        // Act
        var exception = Record.Exception(() => service.VerifyRegister(newUser));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void VerifyRegister_WithValidInput_DoesThrow()
    {
        // Arrange
        var mockRepo = new Mock<IRegisterRepository>();
        var mockHasher = new Mock<IPasswordHasher>();
        var mockValidator = new Mock<IRegisterValidator>();
        var service = new RegisterService(mockRepo.Object, mockHasher.Object, mockValidator.Object);

        var newUser = new RegisterDTO
        {
            Email = "test@example.com",
            UserName = "validUser",
            Password = "Weak"
        };

        mockRepo
            .Setup(registerRepo => registerRepo.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
            .Returns(true); // user does exist

        mockValidator
            .Setup(validator => validator.ValidateAll(newUser.Email, newUser.Password, newUser.UserName))
            .Returns(new List<string>() { "Password is too weak" });

        // Act
        var (isValid, errors) = service.VerifyRegister(newUser);

        // Assert
        Assert.False(isValid);
        Assert.NotEmpty(errors);
    }
}