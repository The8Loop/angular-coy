using CoYBackend.Models;

namespace CoYBackend.Services
{
  public class ToDTO
  {

    public MoneyDTO ToMoneyDTO(Money m)
    {
      var moneyDTO = new MoneyDTO()
      {
        Contribution = m.Contribution,
        Date = m.Date,
        ContributionTypeId = m.ContributionTypeId,
        UserId = m.UserId
      };
      return moneyDTO;
    }
  }


  //   public class UserContDTO
  //   {
  //     public string Name { get; set; }

  //     public List<long>? Contributions { get; set; }
  //   }

  //   public class UserDTO
  //   {
  //     public int Id { get; set; }
  //     public string Name { get; set; }
  //   }
}