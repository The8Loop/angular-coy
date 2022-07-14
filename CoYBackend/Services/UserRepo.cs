using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface IUserRepo
  {
    Task Delete(User user);
    Task<IEnumerable<User>> Get();
    Task<User> Get(int Id);
    Task<IEnumerable<User>> GetAll();
    Task Post(User user);
    Task Post(Money money);
    Task Put(int Id, UserDTO userDTO, User user);
    IEnumerable<TotalSP> GetPlayerTotal(int Id);
    IEnumerable<Leaderboard> GetLeaderboard();
    Task<User> GetUserLogin(string name);
  }

  public class UserRepo : IUserRepo
  {
    private readonly CoYBackendContext _context;

    public UserRepo(CoYBackendContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      return await _context.users.ToListAsync();
    }

    public async Task<IEnumerable<User>> Get()
    {
      return await _context.users.Include(u => u.Contributions).ThenInclude(c => c.ContributionType).ToListAsync();
    }

    public async Task<User> Get(int Id)
    {
      return await _context.users.Include(i => i.Contributions).ThenInclude(c => c.ContributionType).FirstOrDefaultAsync(i => i.Id == Id);
    }

    public async Task Post(User user)
    {
      _context.users.Add(user);
      await _context.SaveChangesAsync();
    }

    public async Task Post(Money money)
    {
      _context.money.Add(money);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
      _context.users.Remove(user);
      await _context.SaveChangesAsync();
    }

    public async Task Put(int Id, UserDTO userDTO, User user)
    {
      user.Name = userDTO.Name;
      user.IsActive = userDTO.IsActive;
      await _context.SaveChangesAsync();
    }

    public IEnumerable<TotalSP> GetPlayerTotal(int Id)
    {
      return _context.Set<TotalSP>().FromSqlRaw($"CALL GetPlayerTotal({Id});").ToList();
    }

    public IEnumerable<Leaderboard> GetLeaderboard()
    {
      return _context.Set<Leaderboard>().FromSqlRaw($"CALL Leaderboard();").ToList();
    }

    public async Task<User> GetUserLogin(string name)
    {
      return await _context.users.FirstOrDefaultAsync(i => i.Name == name);
    }
  }
}