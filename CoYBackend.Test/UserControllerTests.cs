using Xunit;
using CoYBackend.Controllers;
using CoYBackend.Models;
using CoYBackend.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CoYBackend.Test;

public class UserControllerTests
{
  private readonly UnitTestController unitTestController = new UnitTestController();
  private readonly Mock<IUserRepo> _userRepo = new Mock<IUserRepo>();
  private readonly Mock<ISessionRepo> _sessionRepo;
  private ToDTO _toDTO = new ToDTO();

  public UserControllerTests()
  {
    _sessionRepo = new Mock<ISessionRepo>();
  }

  [Fact]
  public void Test1()
  {
    Assert.NotNull(unitTestController.Get());
  }

  [Fact]
  public void Test2()
  {
    Assert.Equal("shit works", unitTestController.Get());
  }

  [Fact]
  public void Test3()
  {
    UserSignupDTO User = new UserSignupDTO
    {
      Name = "name",
      Password = "pass"
    };
    var call = unitTestController.GetUserTest();
    Assert.Equal(call.Value.Name, User.Name);
  }

  [Fact]
  public async void Test4()
  {
    //Arrange
    _userRepo.Setup(x => x.Get(1)).Returns(Task.FromResult(Get()));
    var userController = new UserController(_userRepo.Object, _sessionRepo.Object);

    //Act
    var actionResult = userController.Get(1);
    var DTO = _toDTO.ToUserContDTO(Get());

    //Assert
    Assert.NotNull(actionResult);
    Assert.IsType<Task<ActionResult<UserContDTO>>>(actionResult);
    Assert.Equal(DTO.Name, actionResult.Result.Value.Name);
  }

  private User Get()
  {
    User user = new User
    {
      Id = 1,
      Name = "John Doe",
      IsActive = true,
      Password = "password",
      Salt = "salt",
      AlgorithmId = 1,
      Contributions = new List<Money>()
    };
    return user;
  }
}