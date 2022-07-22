namespace CoYBackend.Models
{
  public class Session
  {
    public uint Id { get; set; }
    public int UserId { get; set; }
    public string SessionString { get; set; }
    public DateTime Creation { get; set; }

    //Navigation Properties
    public User User { get; set; }
  }

  public class SessionDTO
  {
    public string SessionString { get; set; }
    public int UserId { get; set; }
  }
}