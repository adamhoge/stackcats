using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackCats.Web.Context;
using StackCats.Web.Models;
using StackCats.Web.Repositories;

namespace StackCats.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReleaseNotificationRequestRepository _requestRepository;

        public HomeController(IReleaseNotificationRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RequestReleaseNotification(string emailAddress)
        {
            var releaseNotificationRequest = new ReleaseNotificationRequest
            {
                RequesterEmail = emailAddress,
                RequestedAt = DateTime.UtcNow
            };

            if (!releaseNotificationRequest.IsValidForCreate())
            {
                return new JsonResult(false);
            }

            if (!_requestRepository.EmailExists(releaseNotificationRequest.RequesterEmail))
            {
                _requestRepository.Add(releaseNotificationRequest);
            }

            return new JsonResult(true);
        }

        [HttpGet]
        public ActionResult TestRequest(string emailAddress)
        {
            var releaseNotificationRequest = new ReleaseNotificationRequest
            {
                RequesterEmail = emailAddress,
                RequestedAt = DateTime.UtcNow
            };

            if (!releaseNotificationRequest.IsValidForCreate())
            {
                return new JsonResult(false);
            }

            if (!_requestRepository.EmailExists(releaseNotificationRequest.RequesterEmail))
            {
                _requestRepository.Add(releaseNotificationRequest);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
