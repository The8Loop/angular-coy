namespace CoYBackend.Models
{
  public class UserContDTO
  {
    public string Name { get; set; }

    public List<long>? Contributions { get; set; }
  }

  public class UserDTO
  {
    public string Name { get; set; }
  }
}