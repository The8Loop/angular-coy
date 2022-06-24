using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface IMoneyRepo
  {
    Task<IActionResult> DeleteMoney(Money money);
    Task<IEnumerable<Money>> Getmoney();
    Task<Money> GetMoney(int id);
  }

  public class MoneyRepo : ControllerBase, IMoneyRepo
  {
    private readonly CoYBackendContext _context;
    public MoneyRepo(CoYBackendContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Money>> Getmoney()
    {
      var moneyList = await _context.money.ToListAsync();
      return moneyList;
    }

    public async Task<Money> GetMoney(int id)
    {
      return await _context.money.FindAsync(id);
    }

    public async Task<IActionResult> DeleteMoney(Money money)
    {
      _context.money.Remove(money);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}