using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Darzelis.Data;
using Darzelis.Web.Models;
using Darzelis.Models.Entities;
using Darzelis.Data.Contracts;
using Darzelis.Data.Helpers;

namespace Darzelis.Web.Controllers
{
    [Authorize]
    public class RequestModelsController : Controller
    {
        private RequestDbContext db = new RequestDbContext();
        protected IRequestUow Uow { get; set; }
        public RequestModelsController(IRequestUow uow)
        { 
            Uow = uow;
        }



        // GET: RequestModels/Create
        public ActionResult Create(string errorMessage)
        {
            

            RequestModel naujas = new RequestModel();
            ViewBag.PasirinktasDarzelis_1 = new SelectList(db.Schools, "ID", "Label");            
            ViewBag.PasirinktasDarzelis_2 = new SelectList(db.Schools, "ID", "Label");
            ViewBag.PasirinktasDarzelis_3 = new SelectList(db.Schools, "ID", "Label");
            ViewBag.PasirinktasDarzelis_4 = new SelectList(db.Schools, "ID", "Label");
            ViewBag.PasirinktasDarzelis_5 = new SelectList(db.Schools, "ID", "Label");

            var email = Request.Cookies["navInfo"].Value.Split('&')[1].Split('=')[1];
            var user = db.Users.First(x => x.Email == email);
            IList<User> listUser = new List<User>();
            listUser.Add(user);

            naujas.VaikoGimimoData = user.Metai;
            naujas.PrasymoPateikimoData = DateTime.Now;//Datetime.Today();

            ViewBag.VaikoId = new SelectList(listUser, "Id", "Vardas");

            IList<DateTime> dateTimeList = new List<DateTime>();
            DateTime today = DateTime.Today;
            int count = 10;
            int row = 0;
            if(DateTime.Today.Month>05)
            {
                row++;
            }
            while ( row < count)
            {

                dateTimeList.Add(new DateTime(today.Year+row, 05, 01, 0, 0, 0));
                row++;
            }
            IList<SelectListItem> times = new List<SelectListItem>();
            foreach(var time in dateTimeList)
            {
                times.Add(new SelectListItem
                {
                    Text = time.ToString("yyyy-MM-dd"),
                    Value = time.ToString("yyyy-MM-dd"),
                    Selected = false
                });
            }


            ViewBag.LankymoData = times;

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                naujas.ErrorMessage = errorMessage;
            }
            return View(naujas);
        }

        // POST: RequestModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,PrasymoPateikimoData,VaikoId,VaikoGimimoData,LankymoData,VaikoSeniunija,Prioritetas_DeklaruotasMiestas,Prioritetas_3_ar_Daugiau_Vaiku,Prioritetas_seimosdarbingumoLygis,Prioritetas_auginaTikVienasTevas,PasirinktasDarzelis_1,UzpildytasDarzelis_1,DarzelioVietaEileje_1,Darzelio_seniūnija_1,DarzelioGrupesUgdymojiKalba_1,DarzelioGrupesUgdymoMetodika_1,DarzelioGrupesTipas_1,DarzelioAmziausIntervalas_1,AtitinkaDarzelioPriskirtaTeritorija_1,DarzeliLankoBrolysSeserys_1,TinkamaGrupeDarzelyje_1,PasirinktasDarzelis_2,UzpildytasDarzelis_2,DarzelioVietaEileje_2,Darzelio_seniūnija_2,DarzelioGrupesUgdymojiKalba_2,DarzelioGrupesUgdymoMetodika_2,DarzelioGrupesTipas_2,DarzelioAmziausIntervalas_2,AtitinkaDarzelioPriskirtaTeritorija_2,DarzeliLankoBrolysSeserys_2,TinkamaGrupeDarzelyje_2,PasirinktasDarzelis_3,UzpildytasDarzelis_3,DarzelioVietaEileje_3,Darzelio_seniūnija_3,DarzelioGrupesUgdymojiKalba_3,DarzelioGrupesUgdymoMetodika_3,DarzelioGrupesTipas_3,DarzelioAmziausIntervalas_3,AtitinkaDarzelioPriskirtaTeritorija_3,DarzeliLankoBrolysSeserys_3,TinkamaGrupeDarzelyje_3,PasirinktasDarzelis_4,UzpildytasDarzelis_4,DarzelioVietaEileje_4,Darzelio_seniūnija_4,DarzelioGrupesUgdymojiKalba_4,DarzelioGrupesUgdymoMetodika_4,DarzelioGrupesTipas_4,DarzelioAmziausIntervalas_4,AtitinkaDarzelioPriskirtaTeritorija_4,DarzeliLankoBrolysSeserys_4,TinkamaGrupeDarzelyje_4,PasirinktasDarzelis_5,UzpildytasDarzelis_5,DarzelioVietaEileje_5,Darzelio_seniūnija_5,DarzelioGrupesUgdymojiKalba_5,DarzelioGrupesUgdymoMetodika_5,DarzelioGrupesTipas_5,DarzelioAmziausIntervalas_5,AtitinkaDarzelioPriskirtaTeritorija_5,DarzeliLankoBrolysSeserys_5,TinkamaGrupeDarzelyje_5")] RequestModel requestModel)
        {
           
            if (requestModel.PasirinktasDarzelis_1 == requestModel.PasirinktasDarzelis_2
                || requestModel.PasirinktasDarzelis_1 == requestModel.PasirinktasDarzelis_3
                || requestModel.PasirinktasDarzelis_1 == requestModel.PasirinktasDarzelis_4
                || requestModel.PasirinktasDarzelis_1 == requestModel.PasirinktasDarzelis_5

                || requestModel.PasirinktasDarzelis_2 == requestModel.PasirinktasDarzelis_1
                || requestModel.PasirinktasDarzelis_2 == requestModel.PasirinktasDarzelis_3
                || requestModel.PasirinktasDarzelis_2 == requestModel.PasirinktasDarzelis_4
                || requestModel.PasirinktasDarzelis_2 == requestModel.PasirinktasDarzelis_5

                || requestModel.PasirinktasDarzelis_3 == requestModel.PasirinktasDarzelis_1
                || requestModel.PasirinktasDarzelis_3 == requestModel.PasirinktasDarzelis_2
                || requestModel.PasirinktasDarzelis_3 == requestModel.PasirinktasDarzelis_4
                || requestModel.PasirinktasDarzelis_3 == requestModel.PasirinktasDarzelis_5

                || requestModel.PasirinktasDarzelis_4 == requestModel.PasirinktasDarzelis_1
                || requestModel.PasirinktasDarzelis_4 == requestModel.PasirinktasDarzelis_2
                || requestModel.PasirinktasDarzelis_4 == requestModel.PasirinktasDarzelis_3
                || requestModel.PasirinktasDarzelis_4 == requestModel.PasirinktasDarzelis_5

                || requestModel.PasirinktasDarzelis_5 == requestModel.PasirinktasDarzelis_1
                || requestModel.PasirinktasDarzelis_5 == requestModel.PasirinktasDarzelis_2
                || requestModel.PasirinktasDarzelis_5 == requestModel.PasirinktasDarzelis_3
                || requestModel.PasirinktasDarzelis_5 == requestModel.PasirinktasDarzelis_4)
            {

                //requestModel.ErrorMessage = "Pasirinkite skirtingus darželius";

                return RedirectToAction("Create","RequestModels",new { errorMessage= "Pasirinkite skirtingus darželius" });
            }
           
            if (ModelState.IsValid)
            {
                PreRequestSchool pasrinktaMokykla1 = new PreRequestSchool();
                pasrinktaMokykla1.DarzelioVietaEileje = requestModel.DarzelioVietaEileje_1; 
                pasrinktaMokykla1.Darzelio_seniūnija = requestModel.Darzelio_seniūnija_1; 
                pasrinktaMokykla1.DarzelioGrupesUgdymojiKalba = requestModel.DarzelioGrupesUgdymojiKalba_1; 
                pasrinktaMokykla1.DarzelioGrupesUgdymoMetodika = requestModel.DarzelioGrupesUgdymoMetodika_1; 
                pasrinktaMokykla1.DarzelioGrupesTipas = requestModel.DarzelioGrupesTipas_1;
                pasrinktaMokykla1.DarzelioAmziausIntervalas = requestModel.DarzelioAmziausIntervalas_1;
                pasrinktaMokykla1.AtitinkaDarzelioPriskirtaTeritorija = requestModel.AtitinkaDarzelioPriskirtaTeritorija_1;
                pasrinktaMokykla1.DarzeliLankoBrolysSeserys = requestModel.DarzeliLankoBrolysSeserys_1;
                pasrinktaMokykla1.TinkamaGrupeDarzelyje = requestModel.TinkamaGrupeDarzelyje_1;
      
                PreRequestSchool pasrinktaMokykla2 = new PreRequestSchool();
                pasrinktaMokykla2.DarzelioVietaEileje = requestModel.DarzelioVietaEileje_2;
                pasrinktaMokykla2.Darzelio_seniūnija = requestModel.Darzelio_seniūnija_2;
                pasrinktaMokykla2.DarzelioGrupesUgdymojiKalba = requestModel.DarzelioGrupesUgdymojiKalba_2;
                pasrinktaMokykla2.DarzelioGrupesUgdymoMetodika = requestModel.DarzelioGrupesUgdymoMetodika_2;
                pasrinktaMokykla2.DarzelioGrupesTipas = requestModel.DarzelioGrupesTipas_2;
                pasrinktaMokykla2.DarzelioAmziausIntervalas = requestModel.DarzelioAmziausIntervalas_2;
                pasrinktaMokykla2.AtitinkaDarzelioPriskirtaTeritorija = requestModel.AtitinkaDarzelioPriskirtaTeritorija_2;
                pasrinktaMokykla2.DarzeliLankoBrolysSeserys = requestModel.DarzeliLankoBrolysSeserys_2;
                pasrinktaMokykla2.TinkamaGrupeDarzelyje = requestModel.TinkamaGrupeDarzelyje_2;
                
                
                PreRequestSchool pasrinktaMokykla3 = new PreRequestSchool();
                pasrinktaMokykla3.DarzelioVietaEileje = requestModel.DarzelioVietaEileje_3;
                pasrinktaMokykla3.Darzelio_seniūnija = requestModel.Darzelio_seniūnija_3;
                pasrinktaMokykla3.DarzelioGrupesUgdymojiKalba = requestModel.DarzelioGrupesUgdymojiKalba_3;
                pasrinktaMokykla3.DarzelioGrupesUgdymoMetodika = requestModel.DarzelioGrupesUgdymoMetodika_3;
                pasrinktaMokykla3.DarzelioGrupesTipas = requestModel.DarzelioGrupesTipas_3;
                pasrinktaMokykla3.DarzelioAmziausIntervalas = requestModel.DarzelioAmziausIntervalas_3;
                pasrinktaMokykla3.AtitinkaDarzelioPriskirtaTeritorija = requestModel.AtitinkaDarzelioPriskirtaTeritorija_3;
                pasrinktaMokykla3.DarzeliLankoBrolysSeserys = requestModel.DarzeliLankoBrolysSeserys_3;
                pasrinktaMokykla3.TinkamaGrupeDarzelyje = requestModel.TinkamaGrupeDarzelyje_3;
                
                PreRequestSchool pasrinktaMokykla4 = new PreRequestSchool();
                pasrinktaMokykla4.DarzelioVietaEileje = requestModel.DarzelioVietaEileje_4;
                pasrinktaMokykla4.Darzelio_seniūnija = requestModel.Darzelio_seniūnija_4;
                pasrinktaMokykla4.DarzelioGrupesUgdymojiKalba = requestModel.DarzelioGrupesUgdymojiKalba_4;
                pasrinktaMokykla4.DarzelioGrupesUgdymoMetodika = requestModel.DarzelioGrupesUgdymoMetodika_4;
                pasrinktaMokykla4.DarzelioGrupesTipas = requestModel.DarzelioGrupesTipas_4;
                pasrinktaMokykla4.DarzelioAmziausIntervalas = requestModel.DarzelioAmziausIntervalas_4;
                pasrinktaMokykla4.AtitinkaDarzelioPriskirtaTeritorija = requestModel.AtitinkaDarzelioPriskirtaTeritorija_4;
                pasrinktaMokykla4.DarzeliLankoBrolysSeserys = requestModel.DarzeliLankoBrolysSeserys_4;
                pasrinktaMokykla4.TinkamaGrupeDarzelyje = requestModel.TinkamaGrupeDarzelyje_4;
                               
                PreRequestSchool pasrinktaMokykla5 = new PreRequestSchool();
                pasrinktaMokykla5.DarzelioVietaEileje = requestModel.DarzelioVietaEileje_5;
                pasrinktaMokykla5.Darzelio_seniūnija = requestModel.Darzelio_seniūnija_5;
                pasrinktaMokykla5.DarzelioGrupesUgdymojiKalba = requestModel.DarzelioGrupesUgdymojiKalba_5;
                pasrinktaMokykla5.DarzelioGrupesUgdymoMetodika = requestModel.DarzelioGrupesUgdymoMetodika_5;
                pasrinktaMokykla5.DarzelioGrupesTipas = requestModel.DarzelioGrupesTipas_5;
                pasrinktaMokykla5.DarzelioAmziausIntervalas = requestModel.DarzelioAmziausIntervalas_5;
                pasrinktaMokykla5.AtitinkaDarzelioPriskirtaTeritorija = requestModel.AtitinkaDarzelioPriskirtaTeritorija_5;
                pasrinktaMokykla5.DarzeliLankoBrolysSeserys = requestModel.DarzeliLankoBrolysSeserys_5;
                pasrinktaMokykla5.TinkamaGrupeDarzelyje = requestModel.TinkamaGrupeDarzelyje_5;
                              

                Request naujas = new Request();

                naujas.LankymoData = requestModel.LankymoData;
                naujas.PrasymoPateikimoData = requestModel.PrasymoPateikimoData;
                naujas.Prioritetas_3_ar_Daugiau_Vaiku = requestModel.Prioritetas_3_ar_Daugiau_Vaiku;
                naujas.Prioritetas_auginaTikVienasTevas = requestModel.Prioritetas_auginaTikVienasTevas;
                naujas.Prioritetas_DeklaruotasMiestas = requestModel.Prioritetas_DeklaruotasMiestas;
                naujas.Prioritetas_seimosdarbingumoLygis = requestModel.Prioritetas_seimosdarbingumoLygis;
                //naujas = requestModel.VaikoId;
                naujas.VaikoId = requestModel.VaikoId;
                naujas.VaikoGimimoData = requestModel.VaikoGimimoData;
                naujas.PrasymoPateikimoData = requestModel.PrasymoPateikimoData;
                User updateUser = db.Users.ToList().FirstOrDefault(x => x.Id == requestModel.VaikoId);
                updateUser.RequestCreated = true;
                naujas.VaikoIDNF = updateUser;


                db.Requests.Add(naujas);
                db.SaveChanges();

                Request getNaujas= Uow.Requests.GetAll().ToList().FirstOrDefault(x => x.VaikoId == requestModel.VaikoId);
                RequestInfo updateInfo1 = new RequestInfo();
                updateInfo1.PasirinktasDarzelis = requestModel.PasirinktasDarzelis_1;
                updateInfo1.PreRequestSchool = pasrinktaMokykla1;
                updateInfo1.RequestIdRef = getNaujas.Id;
                updateInfo1.DarzelioEilesPrioritetas = 1;

                db.RequestInfo.Add(updateInfo1);
                db.SaveChanges();

                RequestInfo updateInfo2 = new RequestInfo();
                updateInfo2.PasirinktasDarzelis = requestModel.PasirinktasDarzelis_2;
                updateInfo2.PreRequestSchool = pasrinktaMokykla2;
                updateInfo2.RequestIdRef = getNaujas.Id;
                updateInfo2.DarzelioEilesPrioritetas = 2;
                db.RequestInfo.Add(updateInfo2);
                db.SaveChanges();

                RequestInfo updateInfo3 = new RequestInfo();
                updateInfo3.PasirinktasDarzelis = requestModel.PasirinktasDarzelis_3;
                updateInfo3.PreRequestSchool = pasrinktaMokykla3;
                updateInfo3.RequestIdRef = getNaujas.Id;
                updateInfo3.DarzelioEilesPrioritetas = 3;
                db.RequestInfo.Add(updateInfo3);
                db.SaveChanges();

                RequestInfo updateInfo4 = new RequestInfo();
                updateInfo4.PasirinktasDarzelis = requestModel.PasirinktasDarzelis_4;
                updateInfo4.PreRequestSchool = pasrinktaMokykla4;
                updateInfo4.RequestIdRef = getNaujas.Id;
                updateInfo4.DarzelioEilesPrioritetas = 4;
                db.RequestInfo.Add(updateInfo4);
                db.SaveChanges();

                RequestInfo updateInfo5 = new RequestInfo();
                updateInfo5.PasirinktasDarzelis = requestModel.PasirinktasDarzelis_5;
                updateInfo5.PreRequestSchool = pasrinktaMokykla5;
                updateInfo5.RequestIdRef = getNaujas.Id;
                updateInfo5.DarzelioEilesPrioritetas = 5;
                db.RequestInfo.Add(updateInfo5);
                db.SaveChanges();





                return RedirectToAction("Index", "Home");
            }

            return View(requestModel);
        }

      
    }
}
