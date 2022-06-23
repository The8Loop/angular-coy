using CoYBackend.Models;

namespace CoYBackend.Services
{
  public interface IFromDTO
  {
    User FromUserDTO(UserDTO u);
  }

  public class FromDTO : IFromDTO
  {
    public User FromUserDTO(UserDTO u)
    {
      var user = new User()
      {
        Id = u.Id,
        Name = u.Name
      };
      return user;
    }
  }
}