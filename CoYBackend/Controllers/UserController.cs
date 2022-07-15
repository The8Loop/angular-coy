using Microsoft.AspNetCore.Mvc;
using CoYBackend.Models;
using CoYBackend.Services;
using System.Security.Cryptography;
using System.Text;
using System;

namespace CoYBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ToDTO _toDTO;
    private readonly FromDTO _fromDTO;
    private readonly IUserRepo _userRepo;

    public UserController(IUserRepo UserRepo)
    {
      _userRepo = UserRepo;
      _toDTO = new ToDTO();
      _fromDTO = new FromDTO();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
      var userList = await _userRepo.GetAll();
      var userDTOList = userList.Select(u => _toDTO.ToUserDTO(u)).ToList();
      return userDTOList;
    }

    [HttpGet("Money")]
    public async Task<ActionResult<IEnumerable<UserContDTO>>> Get()
    {
      var userList = await _userRepo.Get();
      var userDTOList = userList.Select(u => _toDTO.ToUserContDTO(u)).ToList();
      return userDTOList;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<UserContDTO>> Get(int Id)
    {
      var user = await _userRepo.Get(Id);
      if (user == null)
      {
        return NotFound();
      }
      return _toDTO.ToUserContDTO(user);
    }

    // [HttpPost]
    // public async Task<ActionResult<User>> Post(UserDTO userDTO)
    // {
    //   var user = _fromDTO.FromUserDTO(userDTO);
    //   await _userRepo.Post(user);
    //   return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
    // }

    [HttpPost]
    public async Task<ActionResult<User>> Post(UserSignupDTO userSignupDTO)
    {
      const int SALT_SIZE = 24; // size in bytes
      const int HASH_SIZE = 24; // size in bytes
      const int ITERATIONS = 100000; // number of pbkdf2 iterations

      // Generate a salt
      var provider = RandomNumberGenerator.Create();
      byte[] salt = new byte[SALT_SIZE];
      provider.GetBytes(salt);

      // Generate the hash
      Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(userSignupDTO.Password, salt, ITERATIONS);

      userSignupDTO.Password = Convert.ToHexString(pbkdf2.GetBytes(HASH_SIZE));
      var user = _fromDTO.FromUserDTO(userSignupDTO, Convert.ToHexString(salt));
      try
      {
        await _userRepo.Post(user);
      }
      catch
      {
        return StatusCode(409);
      }
      return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
    }

    [HttpPost("Money")]
    public async Task<ActionResult<Money>> Post(MoneyDTO moneyDTO)
    {
      if (moneyDTO.Contribution == 0 || moneyDTO.UserId == 0 || moneyDTO.ContributionTypeId < 1 || moneyDTO.ContributionTypeId > 4)
      {
        return BadRequest();
      }
      var money = _fromDTO.FromMoneyDTO(moneyDTO);
      await _userRepo.Post(money);
      return CreatedAtAction(nameof(MoneyController.GetMoney), "Money", new { id = money.Id }, money);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
      var user = await _userRepo.Get(Id);
      if (user == null)
      {
        return NotFound();
      }
      await _userRepo.Delete(user);
      return NoContent();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int Id, UserDTO userDTO)
    {
      if (Id != userDTO.Id)
      {
        return BadRequest();
      }

      var user = await _userRepo.Get(Id);
      if (user == null)
      {
        return NotFound();
      }

      await _userRepo.Put(Id, userDTO, user);

      return NoContent();
    }

    [HttpGet("Money/{Id}")]
    public ActionResult<TotalSP> GetPlayerTotal(int Id)
    {
      var output = _userRepo.GetPlayerTotal(Id);
      if (output == null)
      {
        return NotFound();
      }
      return output.ElementAt(0);
    }

    [HttpGet("Leaderboard")]
    public ActionResult<IEnumerable<Leaderboard>> GetLeaderboard()
    {
      var output = _userRepo.GetLeaderboard();
      if (output == null)
      {
        return NotFound();
      }
      return output.ToList();
    }


    [HttpPost("Login")]
    public async Task<ActionResult<Boolean>> GetUserLogin(UserSignupDTO userLogin)
    {
      User user = await _userRepo.GetUserLogin(userLogin.Name);
      if (user == null)
      {
        return false;
      }

      const int HASH_SIZE = 24; // size in bytes
      const int ITERATIONS = 100000; // number of pbkdf2 iterations

      //Get salt in byte[]
      byte[] salt = Convert.FromHexString(user.Salt);

      // Generate the hash
      Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(userLogin.Password, salt, ITERATIONS);
      userLogin.Password = Convert.ToHexString(pbkdf2.GetBytes(HASH_SIZE));

      return (user.Password == userLogin.Password);
    }
  }
}