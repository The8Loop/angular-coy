using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface IMoneyRepo
  {
    Task<IActionResult> DeleteMoney(int id);
    Task<ActionResult<IEnumerable<MoneyDTO>>> Getmoney();
    Task<ActionResult<MoneyDTO>> GetMoney(int id);
  }

  public class MoneyRepo : ControllerBase, IMoneyRepo
  {
    private readonly ToDTO _toDTO;
    private readonly FromDTO _fromDTO;
    private readonly CoYBackendContext _context;
    public MoneyRepo(CoYBackendContext context)
    {
      _context = context;
      _toDTO = new ToDTO();
      _fromDTO = new FromDTO();
    }

    public async Task<ActionResult<IEnumerable<MoneyDTO>>> Getmoney()
    {
      var moneyList = await _context.money.ToListAsync();
      var toDTO = new ToDTO();
      var moneyDTOList = moneyList.Select(m => toDTO.ToMoneyDTO(m)).ToList();
      return moneyDTOList;
    }

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
  }
}