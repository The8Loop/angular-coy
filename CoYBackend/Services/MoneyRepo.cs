using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface IMoneyRepo
  {
    Task DeleteMoney(Money money);
    Task<IEnumerable<Money>> Getmoney();
    Task<Money> GetMoney(int id);
    Task Put(int Id, MoneyDTO moneyDTO, Money money);
  }

  public class MoneyRepo : IMoneyRepo
  {
    private readonly CoYBackendContext _context;
    public MoneyRepo(CoYBackendContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Money>> Getmoney()
    {
      return await _context.money.Include(m => m.ContributionType).ToListAsync();
    }

    public async Task<Money> GetMoney(int id)
    {
      return await _context.money.FindAsync(id);
    }

    public async Task DeleteMoney(Money money)
    {
      _context.money.Remove(money);
      await _context.SaveChangesAsync();
    }

    public async Task Put(int Id, MoneyDTO moneyDTO, Money money)
    {
      money.Contribution = moneyDTO.Contribution;
      money.ContributionTypeId = moneyDTO.ContributionTypeId;
      await _context.SaveChangesAsync();
    }
  }
}