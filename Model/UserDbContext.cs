using Microsoft.EntityFrameworkCore;

namespace GraphQLApiDemo.Model
{
    public class UserDbContext:DbContext
    {
        public DbSet<UserDetailsModel> DemoUserDetails { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
