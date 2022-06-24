using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;
using CoYBackend.Controllers;

namespace CoYBackend.Services
{
  public interface IUserRepo
  {
    Task<IActionResult> Delete(int Id);
    Task<ActionResult<IEnumerable<UserContDTO>>> Get();
    Task<ActionResult<UserContDTO>> Get(int Id);
    Task<ActionResult<IEnumerable<UserDTO>>> GetAll();
    Task<ActionResult<User>> Post(UserDTO userDTO);
    Task<ActionResult<Money>> Post(MoneyDTO moneyDTO);
    Task<ActionResult> Put(int Id, User user);
  }

  public class UserRepo : ControllerBase, IUserRepo
  {
    private readonly ToDTO _toDTO;
    private readonly FromDTO _fromDTO;
    private readonly CoYBackendContext _context;

    public UserRepo(CoYBackendContext context)
    {
      _context = context;
      _toDTO = new ToDTO();
      _fromDTO = new FromDTO();
    }

    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
    {
      var userList = await _context.users.ToListAsync();
      var userDTOList = userList.Select(u => _toDTO.ToUserDTO(u)).ToList();
      return userDTOList;
    }

    public async Task<ActionResult<IEnumerable<UserContDTO>>> Get()
    {
      var userList = await _context.users.Include(u => u.Contributions).ToListAsync();
      var userDTOList = userList.Select(u =>
      {
        return _toDTO.ToUserContDTO(u);
      }).ToList();
      return userDTOList;
    }

    public async Task<ActionResult<UserContDTO>> Get(int Id)
    {
      var user = await _context.users.Include(i => i.Contributions).FirstAsync(i => i.Id == Id);
      if (user == null)
      {
        return NotFound();
      }

      return _toDTO.ToUserContDTO(user);
    }

    public async Task<ActionResult<User>> Post(UserDTO userDTO)
    {
      var user = _fromDTO.FromUserDTO(userDTO);
      _context.users.Add(user);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
    }

    public async Task<ActionResult<Money>> Post(MoneyDTO moneyDTO)
    {
      if (moneyDTO.Contribution == 0 || moneyDTO.UserId == 0)
      {
        return BadRequest();
      }
      var money = _fromDTO.FromMoneyDTO(moneyDTO);
      _context.money.Add(money);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(MoneyController.GetMoney), "Money", new { id = money.Id }, money);
    }

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