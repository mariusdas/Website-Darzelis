using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Darzelis.Web.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            if (Request.Cookies["navInfo"] != null)
            {
                Response.Cookies["navInfo"].Expires = DateTime.Now.AddYears(-350);

            }

            if (Request.Cookies["SessionId"] != null)
            {
                Response.Cookies["SessionId"].Expires = DateTime.Now.AddYears(-350);

            }
            if(Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-350);
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}