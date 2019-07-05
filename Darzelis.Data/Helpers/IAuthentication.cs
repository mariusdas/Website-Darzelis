using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darzelis.Data.Helpers
{
    public interface IAuthentication
    {
        User Authentication(string username, string password);
    }
}
