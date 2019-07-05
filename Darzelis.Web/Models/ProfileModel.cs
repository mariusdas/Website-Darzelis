using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darzelis.Web.Models
{
    public class ProfileModel
    {
        public User user { get; set; }
        public Request UserRequest { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public AlgorithmDataModel ProfileView { get; set; }
        public void get(IRequestUow Uow)
        {
            user = Uow.Users.GetAll().FirstOrDefault(x => x.Email == Email && x.Username == Username);
            if (user.VaikoINDnr != 1)
            {
                UserRequest = Uow.Requests.GetAllIncludeRequest().FirstOrDefault(x => x.VaikoId == user.Id);

                var temp = new AlgorithmDataModel();
                temp.Id = UserRequest.Id;
                temp.PrasymoPateikimoData = UserRequest.PrasymoPateikimoData;
                temp.VaikoId = UserRequest.VaikoId;
                temp.VaikoIDNF = UserRequest.VaikoIDNF;
                temp.VaikoGimimoData = UserRequest.VaikoGimimoData;
                temp.LankymoData = UserRequest.LankymoData;
                temp.VaikoSeniunija = UserRequest.VaikoSeniunija;
                temp.Prioritetas_DeklaruotasMiestas = UserRequest.Prioritetas_DeklaruotasMiestas;
                temp.Prioritetas_3_ar_Daugiau_Vaiku = UserRequest.Prioritetas_3_ar_Daugiau_Vaiku;
                temp.Prioritetas_seimosdarbingumoLygis = UserRequest.Prioritetas_seimosdarbingumoLygis;
                temp.Prioritetas_auginaTikVienasTevas = UserRequest.Prioritetas_auginaTikVienasTevas;

                IList<RequestInfo> GetInfoListById = Uow.RequestInfo.GetAll().ToList().Where(x => x.RequestIdRef == UserRequest.Id).ToList().OrderBy(z => z.DarzelioEilesPrioritetas).ToList();

                temp.PasirinktasDarzelis_1 = GetInfoListById[0].PasirinktasDarzelis;
                temp.PreSchool1 = Uow.Schools.GetById(GetInfoListById[0].PasirinktasDarzelis.Value);
                temp.UzpildytasDarzelis_1 = GetInfoListById[0].UzpildytasDarzelis;
                temp.PreRequestSchool1 = Uow.PreRequestSchool.GetById(GetInfoListById[0].UzpildytasDarzelis.Value);

                temp.PasirinktasDarzelis_2 = GetInfoListById[1].PasirinktasDarzelis;
                temp.PreSchool2 = Uow.Schools.GetById(GetInfoListById[1].PasirinktasDarzelis.Value);
                temp.UzpildytasDarzelis_2 = GetInfoListById[1].UzpildytasDarzelis;
                temp.PreRequestSchool2 = Uow.PreRequestSchool.GetById(GetInfoListById[1].UzpildytasDarzelis.Value);

                temp.PasirinktasDarzelis_3 = GetInfoListById[2].PasirinktasDarzelis;
                temp.PreSchool3 = Uow.Schools.GetById(GetInfoListById[2].PasirinktasDarzelis.Value);
                temp.UzpildytasDarzelis_3 = GetInfoListById[2].UzpildytasDarzelis;
                temp.PreRequestSchool3 = Uow.PreRequestSchool.GetById(GetInfoListById[2].UzpildytasDarzelis.Value);

                temp.PasirinktasDarzelis_4 = GetInfoListById[3].PasirinktasDarzelis;
                temp.PreSchool4 = Uow.Schools.GetById(GetInfoListById[3].PasirinktasDarzelis.Value);
                temp.UzpildytasDarzelis_4 = GetInfoListById[3].UzpildytasDarzelis;
                temp.PreRequestSchool4 = Uow.PreRequestSchool.GetById(GetInfoListById[3].UzpildytasDarzelis.Value);

                temp.PasirinktasDarzelis_5 = GetInfoListById[4].PasirinktasDarzelis;
                temp.PreSchool5 = Uow.Schools.GetById(GetInfoListById[4].PasirinktasDarzelis.Value);
                temp.UzpildytasDarzelis_5 = GetInfoListById[4].UzpildytasDarzelis;
                temp.PreRequestSchool5 = Uow.PreRequestSchool.GetById(GetInfoListById[4].UzpildytasDarzelis.Value);


                temp.PrioritetuSuma = UserRequest.PrioritetuSuma;
                temp.Accepted = UserRequest.Accepted;
                temp.PriimtasDarzelis = UserRequest.PriimtasDarzelis;
                ProfileView = temp;
            }
        }
    }
}