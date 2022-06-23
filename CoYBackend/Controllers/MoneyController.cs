#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;
using CoYBackend.Services;


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
    public async Task<ActionResult<IEnumerable<MoneyDTO>>> Getmoney()
    {
      var moneyList = await _context.money.ToListAsync();
      var toDTO = new ToDTO();
      var moneyDTOList = moneyList.Select(m => toDTO.ToMoneyDTO(m)).ToList();
      return moneyDTOList;
    }

    // GET: api/Money/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MoneyDTO>> GetMoney(int id)
    {
      var money = await _context.money.FindAsync(id);
      var toDTO = new ToDTO();

      if (money == null)
      {
        return NotFound();
      }

      var moneyDTO = toDTO.ToMoneyDTO(money);
      return moneyDTO;
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