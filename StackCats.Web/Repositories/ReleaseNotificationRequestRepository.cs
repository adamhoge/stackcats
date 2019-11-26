using System.Collections.Generic;
using System.Linq;
using StackCats.Web.Context;

namespace StackCats.Web.Repositories
{
    public interface IReleaseNotificationRequestRepository
    {
        void Add(ReleaseNotificationRequest entity);
        bool EmailExists(string email);
    }

    public class ReleaseNotificationRequestRepository : IReleaseNotificationRequestRepository
    {
        private readonly ReleaseNotificationRequestContext _context;

        public ReleaseNotificationRequestRepository(ReleaseNotificationRequestContext context)
        {
            _context = context;
        }

        public void Add(ReleaseNotificationRequest entity)
        {
            _context.ReleaseNotificationRequests.Add(entity);
            _context.SaveChanges();
        }

        public bool EmailExists(string email)
        {
            string emailToLower = email.ToLower();

            return _context.ReleaseNotificationRequests
                .FirstOrDefault(r => r.RequesterEmail.ToLower() == emailToLower) != null;
        }
    }
}