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
    private readonly ToDTO _toDTO;
    private readonly FromDTO _fromDTO;
    private readonly IMoneyRepo _moneyRepo;

    public MoneyController(IMoneyRepo MoneyRepo)
    {
      _moneyRepo = MoneyRepo;
      _toDTO = new ToDTO();
      _fromDTO = new FromDTO();
    }

    // GET: api/Money
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MoneyDTO>>> Getmoney()
    {
      var moneyList = await _moneyRepo.Getmoney();
      return moneyList.Select(m => _toDTO.ToMoneyDTO(m)).ToList();
    }

    // GET: api/Money/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MoneyDTO>> GetMoney(int id)
    {
      var money = await _moneyRepo.GetMoney(id);
      if (money == null)
      {
        return NotFound();
      }
      return _toDTO.ToMoneyDTO(money); ;
    }

    // DELETE: api/Money/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMoney(int id)
    {
      var money = await _moneyRepo.GetMoney(id);
      if (money == null)
      {
        return NotFound();
      }
      await _moneyRepo.DeleteMoney(money);

      return NoContent();
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(int Id, MoneyDTO moneyDTO)
    {
      if (Id != moneyDTO.Id)
      {
        return BadRequest();
      }
      bool tracking = true;
      var money = await _moneyRepo.GetMoney(Id, tracking);
      if (money == null)
      {
        return NotFound();
      }

      money = _fromDTO.FromMoneyDTO(moneyDTO);

      await _moneyRepo.Put(Id, money);

      return NoContent();
    }

    [HttpGet("Company")]
    public IEnumerable<TotalSP> GetCompanyTotal()
    {
      return _moneyRepo.GetCompanyTotal();
    }
  }
}