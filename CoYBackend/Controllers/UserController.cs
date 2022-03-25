using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly CoYBackendContext _context;

    public UserController(CoYBackendContext context)
    {
      _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
      var userList = await _context.users.ToListAsync();
      var userDTOList = userList.Select(u =>
      {
        var userDTO = new UserDTO()
        {
          Name = u.Name
        };
        return userDTO;
      }).ToList();
      return userDTOList;
    }

    [HttpGet("Money")]
    public async Task<ActionResult<IEnumerable<UserContDTO>>> Get()
    {
      var userList = await _context.users.Include(u => u.Contributions).ToListAsync();
      var userDTOList = userList.Select(u =>
      {
        var userContributions = u.Contributions.Select(m =>
        {
          var money = new long();
          money = m.Contribution;
          return money;
        }).ToList();

        var userDTO = new UserContDTO()
        {
          Name = u.Name,
          Contributions = userContributions
        };
        return userDTO;
      }).ToList();
      return userDTOList;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<UserContDTO>> Get(int Id)
    {
      var user = await _context.users.Include(i => i.Contributions).FirstAsync(i => i.Id == Id);

      if (user == null)
      {
        return NotFound();
      }

      if (user.Contributions == null)
      {
        throw new Exception("User contribution is null");
      }

      var userContributions = user.Contributions.Select(m =>
      {
        var money = new long();
        money = m.Contribution;
        return money;
      }).ToList();

      var userDTO = new UserContDTO
      {
        Contributions = userContributions
      };

      return userDTO;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(UserDTO userDTO)
    {
      var user = new User
      {
        Name = userDTO.Name
      };

      _context.users.Add(user);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
    }

    [HttpPost("Money")]
    public async Task<ActionResult<Money>> Post(MoneyDTO moneyDTO)
    {
      if (moneyDTO.Contribution == 0)
      {
        return BadRequest();
      }

      var money = new Money
      {
        Contribution = moneyDTO.Contribution,
        UserId = moneyDTO.UserId
      };
      _context.money.Add(money);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(MoneyController.GetMoney), "Money", new { id = money.Id }, money);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> Put(int Id, User user)
    {
      if (Id != user.Id)
      {
        return BadRequest();
      }

      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_context.users.Any(e => e.Id == Id)) //Check if User user paramater exists in database
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
      var user = await _context.users.FindAsync(Id);
      if (user == null)
      {
        return NotFound();
      }

      _context.users.Remove(user);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}