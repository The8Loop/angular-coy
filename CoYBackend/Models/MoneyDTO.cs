namespace CoYBackend.Models
{
  public class MoneyDTO
  {
    public long Contribution { get; set; }
    public DateTime Date { get; set; }

    //Foreign Key
    public byte ContributionTypeId { get; set; }
    public int UserId { get; set; }
  }
}