using Darzelis.Data.Contracts;
using Darzelis.Data.Helpers;
using Darzelis.Models.ViewModels;
using Darzelis.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Darzelis.Web.Controllers
{
    [Authorize(Roles = UserConstants.AdminRoleName)]
    public class AlgorithmController : ApiBaseController
    {
        
        public AlgorithmController(IRequestUow uow)
        {
            Uow = uow;
        }
        public AlgorithmModel Get( )
        {
            AlgorithmModel model = new AlgorithmModel();
            model.get(Uow);
            return model;

        }

        public AlgorithmModel post(AlgorithmModel model)
        {
            if (model.LankymoData.HasValue
                && string.Format("{0:yyyy-MM-dd}", model.LankymoData.Value) == "2010-01-01")
            {
                model.ResetData(Uow, model.LankymoData.Value);
            }
            model.get(Uow);
           
            return model;
        }


    }
}
