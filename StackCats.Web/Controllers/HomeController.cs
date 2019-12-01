using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackCats.Web.Classes;
using StackCats.Web.Context;
using StackCats.Web.Models;
using StackCats.Web.Repositories;

namespace StackCats.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly IReleaseNotificationRequestRepository _requestRepository;

        public HomeController(
          IOptions<AppSettings> appSettings,
          IReleaseNotificationRequestRepository requestRepository)
        {
            _appSettings = appSettings.Value;
            _requestRepository = requestRepository;
        }

        public IActionResult Index()
        {
            ViewData["ReCaptchaClientKey"] = _appSettings.ReCaptchaClientKey;
            return View();
        }

        [HttpPost]
        public JsonResult RequestReleaseNotification(string emailAddress, string reCaptchaResponse)
        {
            HttpClient httpClient = new HttpClient();
            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={_appSettings.ReCaptchaSecretKey}&response={reCaptchaResponse}").Result;
            if (res.StatusCode != HttpStatusCode.OK)
            {
                return new JsonResult(false);
            }

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
