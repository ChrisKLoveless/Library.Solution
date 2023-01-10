namespace Library.Models
{
  public class AuthorTitle
  {
    public int AuthorTitleId { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int TitleId { get; set; }
    public Title Title { get; set; }
  }
}