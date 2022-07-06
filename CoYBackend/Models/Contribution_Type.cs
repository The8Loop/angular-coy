namespace CoYBackend.Models
{
  public class Contribution_Type
  {
    public byte Id { get; set; }
    public string ContributionType { get; set; }

    //Navigation Property
    public List<Money> Money { get; set; }
  }
}