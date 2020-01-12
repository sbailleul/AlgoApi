using Microsoft.EntityFrameworkCore;

namespace AlgoApi.Models
{
    public class AlgoApiContext : DbContext
    {
        public AlgoApiContext(DbContextOptions<AlgoApiContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}