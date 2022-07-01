using ProfesyonelBackend.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProfesyonelBackend.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    "GorkemGenar", 
                    "gorkem_akkaya@hotmail.com",
                    DateTime.Now.AddDays(15), 
                    new[] {"Admin"}, 
                    false, 
                    "Gorkem Genar",
                    "Akkaya"
                );
            return "User is authenticated !!!";
        }
    }
}