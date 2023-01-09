// Needed for accessing database

using Microsoft.EntityFrameworkCore;


namespace Library.Models 
{
  public class LibraryContext : DbContext 
  {
    public DbSet<ClassName> ClassNames { get; set; }  // CHANGE CLASS NAME!!!

    public LibraryContext(DbContextOptions options) : base(options) { } 
  }
}