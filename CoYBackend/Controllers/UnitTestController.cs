using Microsoft.AspNetCore.Mvc;
using CoYBackend.Models;
using CoYBackend.Services;
using System.Security.Cryptography;
using System;

namespace CoYBackend.Controllers
{
  [Route("api/[unit-test]")]
  [ApiController]
  public class UnitTestController : ControllerBase
  {
    [HttpGet]
    public string Get()
    {
      return "shit works";
    }

    [HttpGet]
    public ActionResult<UserSignupDTO> GetUserTest()
    {
      UserSignupDTO User = new UserSignupDTO
      {
        Name = "name",
        Password = "pass"
      };
      return User;
    }
  }
}