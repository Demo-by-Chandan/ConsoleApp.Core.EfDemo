using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.MacOs
{
    public class DefaultContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=D:\\SqliteDb\\ConsoleApp.db");
        }
    }

    //public class SqlContext : DbContext
    //{
    //    public DbSet<Student> Students { get; set; }
    //    public DbSet<Teacher> Teachers { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlServer(@"");
    //    }
    //}
}