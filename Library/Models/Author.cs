namespace Library.Models 
{
  public class Author 
  {
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public List<AuthorTitle> JoinEntities { get; set; }
  }
}