using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace StackCats.Web.Context
{
    /// <summary>
    /// Contains information for a request for notification upon release of Stack Cats.
    /// </summary>
    public class ReleaseNotificationRequest
    {
        /// <summary>
        /// Key
        /// </summary>
        public int ReleaseNotificationRequestId { get; set; }

        /// <summary>
        /// The email address of the individual submitting the request.
        /// </summary>
        public string RequesterEmail { get; set; }

        /// <summary>
        /// The time at which the request was made.
        /// </summary>
        public DateTime RequestedAt { get; set; }

        /// <summary>
        /// Indicates whether or not the provided email is valid.
        /// </summary>
        /// <returns>A flag indicating whether or not the provided email is valid.</returns>
        public bool IsValidForCreate()
        {
            return Regex.IsMatch(RequesterEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
