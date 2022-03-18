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
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
      return await _context.users.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> Get(int Id)
    {
      var user = await _context.users.FindAsync(Id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
      _context.users.Add(user);

      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
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