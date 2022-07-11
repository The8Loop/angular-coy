namespace CoYBackend.Models
{
  public class User
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }

    //Navigation Property
    public List<Money> Contributions { get; set; }
  }

  public class Leaderboard
  {
    public string Name { get; set; }
    public long total { get; set; }
  }
}