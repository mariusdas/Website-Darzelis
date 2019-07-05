using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Darzelis.Web.Controllers
{
    public class MapController : ApiBaseController
    {
        public MapController(IRequestUow uow)
        {
            Uow = uow;
        }
        [HttpGet]
        public IList<Pre_Schools> GetAllPreSchools()
        {
            return Uow.Schools.GetAll().ToList();
        }
    }
}
