#nullable disable
using Microsoft.AspNetCore.Mvc;
using CoYBackend.Models;
using CoYBackend.Services;

namespace CoYBackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoneyController : ControllerBase
  {
    private readonly IMoneyRepo _moneyRepo;

    public MoneyController(IMoneyRepo MoneyRepo)
    {
      _moneyRepo = MoneyRepo;
    }

    // GET: api/Money
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MoneyDTO>>> Getmoney()
    {
      return await _moneyRepo.Getmoney();
    }

    // GET: api/Money/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MoneyDTO>> GetMoney(int id)
    {
      return await _moneyRepo.GetMoney(id);
    }

    // DELETE: api/Money/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMoney(int id)
    {
      return await _moneyRepo.DeleteMoney(id);
    }
  }
}