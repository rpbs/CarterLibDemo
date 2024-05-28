using LibCarter.Data;
using Microsoft.EntityFrameworkCore;

namespace LibCarter;

public class Context(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring
   (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "CarterDemo");
    }s    

    public DbSet<Car> Cars { get; set; }    
}
