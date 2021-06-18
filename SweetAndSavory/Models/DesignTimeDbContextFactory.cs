using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SweetAndSavory.Models
{
  public class SweetAndSavoryContextFactory : IDesignTimeDbContextFactory<SweetAndSavoryContext>
  {

    SweetAndSavoryContext IDesignTimeDbContextFactory<SweetAndSavoryContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SweetAndSavoryContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new SweetAndSavoryContext(builder.Options);
    }
  }
}

//Ultimately, we need the code above so that our application can properly find our database context.