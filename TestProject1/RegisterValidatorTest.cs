using Evnt_Nxt_Business_.Interfaces;
using Evnt_Nxt_Business_.Services;
using EvntNxtDTO;
using Moq;
using Xunit;

public class RegisterValidatorTest
{
    [Fact]
    public void VerifyRegisterWithValidInputShouldSucceed()
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

        mockRepo.Setup(repo => repo.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
                .Returns(false); // User doesn't exist

        mockValidator.Setup(validator => validator.ValidateAll(newUser.Email, newUser.Password, newUser.UserName))
                     .Returns(new List<string>()); // Gives the right information for it to be validated

        // Act
        var (success, errors) = service.VerifyRegister(newUser);

        // Assert
        Assert.True(success);
        Assert.Empty(errors);
    }

    [Fact]
    public void VerifyRegisterWhenUserAlreadyExistsShouldFail()
    {
        // Arrange
        var mockRepo = new Mock<IRegisterRepository>();
        var mockHasher = new Mock<IPasswordHasher>();
        var mockValidator = new Mock<IRegisterValidator>();

        var service = new RegisterService(mockRepo.Object, mockHasher.Object, mockValidator.Object);

        var newUser = new RegisterDTO
        {
            Email = "test@example.com",
            UserName = "existingUser",
            Password = "StrongPassword"
        };

        mockRepo.Setup(repo => repo.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
                .Returns(true); // User does exist

        mockValidator.Setup(v => v.ValidateAll(newUser.Email, newUser.Password, newUser.UserName))
                     .Returns(new List<string>
                     {
                         "Password must contain at least one digit.",
                         "Password must contain at least one special character (!, @, #, etc.)."
                     });

        // Act
        var (success, errors) = service.VerifyRegister(newUser);

        // Assert
        Assert.False(success);
        Assert.Contains("A user already exists with this email or username.", errors);
        Assert.Contains("Password must contain at least one digit.", errors);
        Assert.Contains("Password must contain at least one special character (!, @, #, etc.).", errors);
    }

    [Fact]
    public void VerifyRegisterWithInvalidPasswordShouldFail()
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
            Password = "123"
        };

        mockRepo.Setup(r => r.CheckUserByEmailAndUserName(newUser.Email, newUser.UserName))
                .Returns(false);

        mockValidator.Setup(validator => validator.ValidateAll(newUser.Email, newUser.Password, newUser.UserName))
                     .Returns(new List<string> { "Password too short" });

        // Act
        var (success, errors) = service.VerifyRegister(newUser);

        // Assert
        Assert.False(success);
        Assert.Contains("Password too short", errors);
    }
}