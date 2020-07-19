using Microsoft.EntityFrameworkCore;
using Wunderlist.DataStore.Models;

namespace Wunderlist.DataStore
{
    public class WunderlistContext : DbContext
    {
        public WunderlistContext(DbContextOptions<WunderlistContext> options)
            : base(options)
        { }

        public DbSet<Notepad> Notepads { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
