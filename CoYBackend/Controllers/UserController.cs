using Microsoft.AspNetCore.Mvc;
using CoYBackend.Models;
using CoYBackend.Services;

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

    [HttpPost]
    public async Task<ActionResult<User>> Post(UserDTO userDTO)
    {
      var user = _fromDTO.FromUserDTO(userDTO);
      await _userRepo.Post(user);
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
  }
}