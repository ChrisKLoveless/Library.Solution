using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Library.Models 
{
  public class LibraryContext : IdentityDbContext<ApplicationUser> 
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