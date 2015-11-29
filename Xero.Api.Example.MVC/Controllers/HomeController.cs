﻿using System.Web.Mvc;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Helpers;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.MVC
{
    public class HomeController : Controller
    {
        private IMvcAuthenticator _authenticator;
        private ApiUser _user;

        public HomeController()
        {
            _user = XeroApiHelper.User();

            _authenticator = XeroApiHelper.MvcAuthenticator();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Connect()
        {
            var authorizeUrl = _authenticator.GetRequestTokenAuthorizeUrl(_user.Name);

            return Redirect(authorizeUrl);
        }

        public ActionResult Authorize(string oauth_token, string oauth_verifier, string org)
        {          
            var accessToken = _authenticator.RetrieveAndStoreAccessToken(_user.Name, oauth_token, oauth_verifier, org);
            if (accessToken == null)
                return View("NoAuthorized");            

            return View(accessToken);
        }
    }
}
