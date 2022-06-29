namespace CoYBackend.Models
{
  public class MoneyDTO
  {
    public int Id { get; set; }
    public long Contribution { get; set; }
    public DateTime Date { get; set; }
    public string ContributionType { get; set; }

    //Foreign Key
    public byte ContributionTypeId { get; set; }
    public int UserId { get; set; }
  }
}