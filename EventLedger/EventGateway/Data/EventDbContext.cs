using EventGateway.Models;
using Microsoft.EntityFrameworkCore;

namespace EventGateway.Data;

public class EventDbContext(DbContextOptions<EventDbContext> options) : DbContext(options)
{
    public DbSet<EventRecord> Events => Set<EventRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
 modelBuilder.Entity<EventRecord>()
            .HasIndex(x => AccountId);

          
modelBuilder.Entity<EventRecord>()
            .HasIndex(x => EventId)
            .IsUnique();

}

       
}
