using Darzelis.Data.Contracts;
using Darzelis.Data.Helpers;
using Darzelis.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Darzelis.Web.Controllers
{
    [Authorize]
    public class ProfileController : ApiBaseController
    {
        
        public ProfileController(IRequestUow uow)
        {
            Uow = uow;
        }
        public ProfileModel Get()
        {
            ProfileModel model = new ProfileModel();
            model.get(Uow);
            return model;

        }

        public ProfileModel post(ProfileModel model)
        {
            model.get(Uow);
            return model;
        }
    }
}
