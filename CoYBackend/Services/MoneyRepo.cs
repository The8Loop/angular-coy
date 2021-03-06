using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface IMoneyRepo
  {
    Task DeleteMoney(Money money);
    Task<IEnumerable<Money>> Getmoney();
    Task<Money> GetMoney(int id, bool tracking = false);
    Task Put(int Id, Money money);
    IEnumerable<TotalSP> GetCompanyTotal();
    Task<IEnumerable<Contribution_Type>> GetAllContributionTypes();
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

    public async Task<Money> GetMoney(int id, bool tracking = false)
    {
      if (tracking = true)
      {
        return await _context.money.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
      }
      return await _context.money.FindAsync(id);
    }

    public async Task DeleteMoney(Money money)
    {
      _context.money.Remove(money);
      await _context.SaveChangesAsync();
    }

    public async Task Put(int Id, Money money)
    {
      _context.Update(money);
      await _context.SaveChangesAsync();
    }

    public IEnumerable<TotalSP> GetCompanyTotal()
    {
      return _context.Set<TotalSP>().FromSqlRaw("CALL GetCompanyTotal();").ToList();
    }

    public async Task<IEnumerable<Contribution_Type>> GetAllContributionTypes()
    {
      return await _context.contribution_type.ToListAsync();
    }
  }
}