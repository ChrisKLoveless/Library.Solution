namespace Library.Models
{
  public class Patron
  {
    public int PatronId { get; set; }
    public string Name { get; set; }
    public List<Checkout> JoinEntities { get; set; }
  }
}