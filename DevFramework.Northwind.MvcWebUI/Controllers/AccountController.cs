using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(
                    Guid.NewGuid()
                    , "ahmetfarukulu"
                    , "ahmetfarukulu@gmail.com"
                    , DateTime.Now.AddMinutes(1)
                    , new[] { "Editor" }
                    , false
                    , "Ahmet Faruk"
                    , "Ulu");
            return "User is authenticated!";
        }
    }
}