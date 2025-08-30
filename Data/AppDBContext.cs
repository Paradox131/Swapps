using Swapps.Models;
using System.Security.Principal;

namespace Swapps.Data
{
    public class AppDBContext : IdentityDBContext<Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
