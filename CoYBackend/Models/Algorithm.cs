namespace CoYBackend.Models
{
  public class Algorithm
  {
    public byte Id { get; set; }
    public string Name { get; set; }

    //Navigation Property
    public List<User> Users { get; set; }
  }
}