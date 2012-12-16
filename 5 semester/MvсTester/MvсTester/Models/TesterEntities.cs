using System.Data.Entity;

namespace MvсTester.Models
{
    public class TesterEntities : DbContext
    {
        public TesterEntities() : base("TesterDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
    }
}