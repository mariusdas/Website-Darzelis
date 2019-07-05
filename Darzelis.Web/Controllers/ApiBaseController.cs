using Darzelis.Data.Contracts;
using Darzelis.Data.Helpers;
using System.Web.Http;

namespace Darzelis.Web.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected IRequestUow Uow { get; set; }
       
    }
}