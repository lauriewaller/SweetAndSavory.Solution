using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetAndSavory.Models
{
  public class SweetAndSavoryContext : IdentityDbContext<ApplicationUser> //Identity is built to use Entity Framework and store user information in a database. It comes with the class IdentityDbContext, which extends Entity Framework's DbContext class to work with user authentication. Notice that we're declaring ApplicationUser as the type of IdentityDbContext we're inheriting in the class declaration. This tells Identity which class in the application will contain the user account information it will be responsible for authenticating.

  {
    public virtual DbSet<Flavor> Categories { get; set; } //Each DbSet we've included will become a table in our database. 
    public DbSet<Treat> Items { get; set; }
    public DbSet<FlavorTreat> CategoryItem { get; set; }

    public SweetAndSavoryContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}