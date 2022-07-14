namespace CoYBackend.Models
{
  public class UserContDTO
  {
    public string Name { get; set; }

    public List<MoneyDTO> Contributions { get; set; }
  }

  public class UserDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
  }

  public class UserSignupDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public string Password { get; set; }
    public byte AlgorithmId { get; set; }
  }
}