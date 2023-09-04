

namespace Devblogs.IdentitiesProvider.Data;

public class IdentitiesDbContext : IdentityDbContext
{
    public IdentitiesDbContext(DbContextOptions<IdentitiesDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



    }
}
