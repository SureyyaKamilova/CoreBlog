using Microsoft.EntityFrameworkCore;

namespace CoreBlogApi.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=CoreBlogApi; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
