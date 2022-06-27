using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;
using CoYBackend.Controllers;

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
  }

  public class UserRepo : IUserRepo
  {
    private readonly ToDTO _toDTO;
    private readonly FromDTO _fromDTO;
    private readonly Validator _validator;
    private readonly CoYBackendContext _context;

    public UserRepo(CoYBackendContext context)
    {
      _context = context;
      _toDTO = new ToDTO();
      _fromDTO = new FromDTO();
      _validator = new Validator();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      return await _context.users.ToListAsync();
    }

    public async Task<IEnumerable<User>> Get()
    {
      return await _context.users.Include(u => u.Contributions).ToListAsync();
    }

    public async Task<User> Get(int Id)
    {
      return await _context.users.Include(i => i.Contributions).FirstOrDefaultAsync(i => i.Id == Id);
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
  }
}