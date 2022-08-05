using Xunit;
using System;
using CoYBackend.Controllers;
using CoYBackend.Services;
using CoYBackend.Models;

namespace CoYBackend.Test;

public class UnitTest1
{
  private UnitTestController unitTestController = new UnitTestController();

  [Fact]
  public void Test1()
  {
    Assert.NotNull(unitTestController.Get());
  }

  [Fact]
  public void Test2()
  {
    Assert.Equal(unitTestController.Get(), "shit works");
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
}