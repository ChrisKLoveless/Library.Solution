// Needed for accessing database

using Microsoft.EntityFrameworkCore;


namespace Library.Models 
{
  public class LibraryContext : DbContext 
  {
    public DbSet<Author> Authors { get; set; } 
    public DbSet<Title> Titles { get; set; } 
    public DbSet<AuthorTitle> AuthorTitles { get; set; } 
    public DbSet<Patron> Patron { get; set; }
    public DbSet<Copy> Copies { get; set; }
    public DbSet<Checkout> Checkouts { get; set; } 

    public LibraryContext(DbContextOptions options) : base(options) { } 
  }
}