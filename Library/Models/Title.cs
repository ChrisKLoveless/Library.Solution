namespace Library.Models
{ 
  public class Title
  {
    public int TitleId { get; set; }
    public string Name { get; set; } 
    public List<AuthorTitle> JoinEntities { get; set; }
    public List<Copy> Copies { get; set; }
  }
}