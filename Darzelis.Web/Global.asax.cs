using System;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Darzelis.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie =Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            var svg = HttpContext.Current.Request.Cookies["SessionId"];
            if (authCookie != null && svg != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket.Name == Encoding.UTF8.GetString(System.Convert.FromBase64String(svg.Value)))
                {
                    string[] roles = authTicket.UserData.Split(new Char[] { ',' });
                    GenericPrincipal userPrincipal = new GenericPrincipal(new GenericIdentity(authTicket.Name), roles);
                    Context.User = userPrincipal;
                }
            }
        }
    }
}
