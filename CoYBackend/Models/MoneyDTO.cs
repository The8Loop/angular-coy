namespace CoYBackend.Models
{
  public class MoneyDTO
  {
    public long Contribution { get; set; }

    //Foreign Key
    public int UserId { get; set; }
  }
}