using Microsoft.AspNet.Identity.EntityFramework;
using WEB_BASE.Models;

namespace WEB_BASE.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection", false)
        {
        }
        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
    }
}