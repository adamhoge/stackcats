using Microsoft.EntityFrameworkCore;

namespace StackCats.Web.Context
{
    public class ReleaseNotificationRequestContext : DbContext
    {
        public ReleaseNotificationRequestContext(DbContextOptions options) : base(options) { }

        public DbSet<ReleaseNotificationRequest> ReleaseNotificationRequests { get; set; }
    }
}
