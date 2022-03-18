#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoneyController : ControllerBase
  {
    private readonly CoYBackendContext _context;

    public MoneyController(CoYBackendContext context)
    {
      _context = context;
    }

    // GET: api/Money
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Money>>> Getmoney()
    {
      return await _context.money.ToListAsync();
    }

    // GET: api/Money/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Money>> GetMoney(int id)
    {
      var money = await _context.money.FindAsync(id);

      if (money == null)
      {
        return NotFound();
      }

      return money;
    }

    // PUT: api/Money/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMoney(int id, Money money)
    {
      if (id != money.Id || money.Contribution == 0)
      {
        return BadRequest();
      }

      _context.Entry(money).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MoneyExists(id))
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

    // POST: api/Money
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Money>> PostMoney(Money money)
    {
      if (money.Contribution == 0)
      {
        return BadRequest();
      }
      _context.money.Add(money);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetMoney", new { id = money.Id }, money);
    }

    // DELETE: api/Money/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMoney(int id)
    {
      var money = await _context.money.FindAsync(id);
      if (money == null)
      {
        return NotFound();
      }

      _context.money.Remove(money);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool MoneyExists(int id)
    {
      return _context.money.Any(e => e.Id == id);
    }
  }
}
