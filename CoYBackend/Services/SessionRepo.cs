using Microsoft.EntityFrameworkCore;
using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface ISessionRepo
  {
    Task Delete(int userId);
    Task<Session> Get(string sessionIdentifier);
    Task Post(Session session);
  }

  public class SessionRepo : ISessionRepo
  {
    private readonly CoYBackendContext _context;
    public SessionRepo(CoYBackendContext context)
    {
      _context = context;
    }

    public async Task<Session> Get(string sessionIdentifier)
    {
      return await _context.sessions.FirstOrDefaultAsync(s => s.SessionString == sessionIdentifier);
    }

    public async Task Post(Session session)
    {
      _context.sessions.Add(session);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int userId)
    {
      var sessionList = await _context.sessions.Where(s => s.UserId == userId).ToListAsync();
      sessionList.ForEach(s => _context.sessions.Remove(s));
      await _context.SaveChangesAsync();
    }
  }
}