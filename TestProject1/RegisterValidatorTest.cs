using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using EvntNxtDTO;
using Moq;
using Xunit;

public class TicketServiceTests
{
    [Fact]
    public void VerifyRegister_WithValidInput_NoErrors()
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
            .Setup(repo => repo.CheckUserByEmailAndUserName(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(false);    // user does not exist

        mockValidator
            .Setup(validator => validator.ValidateAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new List<string>()); // no validation errors

        // Act
        var (isValid, errors) = service.VerifyRegister(newUser);

        // Assert
        Assert.True(isValid);
        Assert.Empty(errors);
    }

    [Fact]
    public void VerifyRegister_WithValidInput_DoesErrors()
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
            .Setup(repo => repo.CheckUserByEmailAndUserName(It.IsAny<string>(), It.IsAny<string>())).Returns(true); // User Does Exist

        mockValidator
            .Setup(validator => validator.ValidateAll(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new List<string>() { "Password is too weak" });

        // Act
        var (isValid, errors) = service.VerifyRegister(newUser);

        // Assert
        Assert.False(isValid);
        Assert.NotEmpty(errors);
    }
}