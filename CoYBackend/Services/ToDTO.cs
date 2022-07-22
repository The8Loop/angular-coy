using CoYBackend.Models;

namespace CoYBackend.Services
{
  public class ToDTO
  {
    public UserDTO ToUserDTO(User u)
    {
      var userDTO = new UserDTO()
      {
        Id = u.Id,
        Name = u.Name,
        IsActive = u.IsActive
      };
      return userDTO;
    }

    public UserContDTO ToUserContDTO(User u)
    {
      var userDTO = new UserContDTO()
      {
        Name = u.Name,
        Contributions = u.Contributions.Select(m => ToMoneyDTO(m)).ToList()
      };
      return userDTO;
    }

    public MoneyDTO ToMoneyDTO(Money m)
    {
      var moneyDTO = new MoneyDTO()
      {
        Id = m.Id,
        Contribution = m.Contribution,
        Date = m.Date,
        ContributionTypeId = m.ContributionTypeId,
        UserId = m.UserId,
        ContributionType = m.ContributionType.ContributionType
      };
      return moneyDTO;
    }

    public SessionDTO ToSessionDTO(Session s)
    {
      var sessionDTO = new SessionDTO()
      {
        SessionString = s.SessionString,
        UserId = s.UserId
      };
      return sessionDTO;
    }
  }
}