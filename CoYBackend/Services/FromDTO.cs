using CoYBackend.Models;

namespace CoYBackend.Services
{
  public class FromDTO
  {
    public User FromUserDTO(UserSignupDTO u, string salt)
    {
      var user = new User()
      {
        Id = u.Id,
        Name = u.Name,
        IsActive = u.IsActive,
        Password = u.Password,
        Salt = salt,
        AlgorithmId = u.AlgorithmId
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
  }
}