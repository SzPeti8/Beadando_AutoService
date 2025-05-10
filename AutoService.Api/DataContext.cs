using Microsoft.EntityFrameworkCore;
using AutoService.Shared;
namespace AutoService.Api
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Work> Works { get; set; }
    }
    
    
}
