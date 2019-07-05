using Darzelis.Data.Helpers;
using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Darzelis.Data
{
    public class FormsAuthenticationProvider : IAuthentication
    {
        private readonly RequestDbContext context = new RequestDbContext();
        public User Authentication(string username, string password)
        {
            try
            {
                var result = context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
        
    }
}
