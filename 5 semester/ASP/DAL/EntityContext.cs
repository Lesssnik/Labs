using Entities;
using System.Data.Entity;

namespace DAL
{
    internal class EntityContext : DbContext
    {
        public EntityContext() : base("TesterDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
    }
    
}
