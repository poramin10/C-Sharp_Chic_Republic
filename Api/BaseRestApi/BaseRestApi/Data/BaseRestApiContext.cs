using BaseRestApi.Models;
using Microsoft.EntityFrameworkCore;


namespace BaseRestApi.Data
{
    public class BaseRestApiContext : DbContext
    {
        public BaseRestApiContext(DbContextOptions<BaseRestApiContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get;set;}
        public DbSet<Branch> Branchs {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}