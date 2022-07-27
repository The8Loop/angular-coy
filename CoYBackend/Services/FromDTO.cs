using CoYBackend.Models;

namespace CoYBackend.Services
{
  public class FromDTO
  {
    public User FromUserDTO(UserSignupDTO u, string salt)
    {
      var user = new User()
      {
        Id = 0,
        Name = u.Name,
        IsActive = true,
        Password = u.Password,
        Salt = salt,
        AlgorithmId = 1
      };
      return user;
    }

    public Money FromMoneyDTO(MoneyDTO m)
    {
      var money = new Money
      {
        Id = m.Id,
        Contribution = m.Contribution,
        Date = m.Date,
        ContributionTypeId = m.ContributionTypeId,
        UserId = m.UserId
      };
      return money;
    }

    public Money FromMoneyPostDTO(MoneyPostDTO m)
    {
      var money = new Money
      {
        Id = 0,
        Contribution = m.Contribution,
        Date = DateTime.Now,
        ContributionTypeId = m.ContributionTypeId,
        UserId = m.UserId
      };
      return money;
    }
  }
}