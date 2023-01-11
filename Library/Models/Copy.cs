namespace Library.Models
{
  public class Copy
  {
    public int CopyId { get; set; }
    public bool Available { get; set; }
    public AuthorTitle AuthorTitle { get; set; }
    public int AuthorTitleId {get; set; }
    public List<Checkout> JoinEntities { get; set; }

  }
}