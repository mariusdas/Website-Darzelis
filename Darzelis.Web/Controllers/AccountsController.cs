using Darzelis.Data.Helpers;
using Darzelis.Web.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Darzelis.Web.Controllers
{
    
    public class AccountsController : ApiController
    {
        private readonly IAuthentication authentication;
        public AccountsController(IAuthentication auth)
        {
            this.authentication = auth;

        }
        
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Post(LoginViewModel login)
        {
            var encPass = AlgorithmsAll.Sha256Algorithm.GetMD5Hash(login.Password);
            var usr = authentication.Authentication(login.Username, encPass);
            if (usr != null)
            {
                
                login.Email = usr.Email;
                login.Type = usr.UserType;
                string auth = login.Username + "|" + login.Email + "|" + login.Type;
               
                

                HttpCookie toolCookie = new HttpCookie("navInfo");
                toolCookie["UserName"] = login.Username;
                toolCookie["Email"] = login.Email;
                toolCookie["Type"] = login.Type.ToString();
                toolCookie["Created"] = usr.RequestCreated.ToString();
                toolCookie.Expires = DateTime.Now.AddHours(24);
                var respo = HttpContext.Current.Response;
               
                respo.Cookies.Add(toolCookie);
                string username = login.Username;
                string password = login.Password;

                

                string roles="";
                if (usr.UserType == 2)
                {
                    roles = "Admin";
                }else
                {
                    roles = "User";
                }
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                  1,
                  username + ":" + login.Email + ":" + login.Type + ":" + usr.Id,  //user id
                  DateTime.Now,
                  DateTime.Now.AddYears(1),  // expiry
                  false,  //do not remember
                  roles,
                  "/");

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                   FormsAuthentication.Encrypt(authTicket));
                respo.Cookies.Add(cookie);

                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + login.Email + ":" + login.Type + ":" + usr.Id));
                HttpCookie sessionCookie = new HttpCookie("SessionId");
                sessionCookie.Value = svcCredentials;
                sessionCookie.Expires = DateTime.Now.AddYears(1);
                respo.Cookies.Add(sessionCookie);

                var response = Request.CreateResponse(HttpStatusCode.Created, login);
                return response;
            }
            else
            {
                ModelState.AddModelError("", "Neteisingas vartotojo vardas arba slaptažodis");
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, login);
                return response;
            }        
        }
    }
}
