using ECommerce.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class IdentityContext : IdentityDbContext<ShopUser, ShopRole, string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        public IdentityContext() : base(GetOptions())
        {

        }

        private static DbContextOptions GetOptions()
        {
            string cs = "Server=.;Database=ZayID;User Id=sa;Password=1234;";
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), cs).Options;
        }

        public DbSet<ECommerce.Entities.Identity.UserRoles> UserRoles { get; set; }
    }
}
