namespace CoYBackend.Models
{
  public class Money
  {
    public int Id { get; set; }
    public long Contribution { get; set; }

    //Foreign Key
    public byte ContributionTypeId { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }

    //Navigation Property
    public User User { get; set; }
    public Contribution_Type ContributionType { get; set; }
  }

  public class TotalSP
  {
    public int total { get; set; }
  }
}