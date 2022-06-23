using Microsoft.AspNetCore.Mvc;
using CoYBackend.Models;
using CoYBackend.Services;

namespace CoYBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly CoYBackendContext _context;
    private readonly IUserRepo _userRepo;

    public UserController(IUserRepo UserRepo, CoYBackendContext context)
    {
      _context = context;
      _userRepo = UserRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
      return await _userRepo.GetAll();
    }

    [HttpGet("Money")]
    public async Task<ActionResult<IEnumerable<UserContDTO>>> Get()
    {
      return await _userRepo.Get();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<UserContDTO>> Get(int Id)
    {
      return await _userRepo.Get(Id);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(UserDTO userDTO)
    {
      return await _userRepo.Post(userDTO);
    }

    [HttpPost("Money")]
    public async Task<ActionResult<Money>> Post(MoneyDTO moneyDTO)
    {
      return await _userRepo.Post(moneyDTO);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> Put(int Id, User user)
    {
      return await _userRepo.Put(Id, user);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
      return await _userRepo.Delete(Id);
    }
  }
}