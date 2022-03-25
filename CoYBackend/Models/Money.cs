namespace CoYBackend.Models
{
  public class Money
  {
    public int Id { get; set; }
    public long Contribution { get; set; }

    //Foreign Key
    public int UserId { get; set; }

    //Navigation Property
    public User User { get; set; }
  }
}