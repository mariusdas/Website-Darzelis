using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using Darzelis.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darzelis.Models.ViewModels
{
    public class AlgorithmModel
    {
        public IList<AlgorithmDataModel> AllRequests { get; set; }
        public IList<AlgorithmDataModel> AllAcceptedRequests { get; set; }
        public IList<AlgorithmDataModel> AllDeclinedRequests { get; set; }
        public IList<Pre_Schools> AllSchools { get; set; }
        public int? PasirinktasDarzelis { get; set; }
        public int? VaikoId { get; set; }
        public string DarzelioPavadinimas { get; set; }
        public int eileVieta { get; set; }
        public int? PasirinktasDarzelis_1 { get; set; }
        public string DarzelioVietaEileje_1 { get; set; }
        public int? PasirinktasDarzelis_2 { get; set; }
        public string DarzelioVietaEileje_2 { get; set; }
        public int? PasirinktasDarzelis_3 { get; set; }
        public string DarzelioVietaEileje_3 { get; set; }
        public int? PasirinktasDarzelis_4 { get; set; }
        public string DarzelioVietaEileje_4 { get; set; }
        public int? PasirinktasDarzelis_5 { get; set; }
        public string DarzelioVietaEileje_5 { get; set; }
        public DateTime? LankymoData { get; set; }

        public void ResetData(IRequestUow Uow,DateTime resetData)
        {
            try
            {
                IList<Request> requestList = Uow.Requests.GetAllIncludeRequest().ToList();
                foreach (var row in requestList)
                {
                    row.Accepted = false;
                    row.PreSchoolAccepted = null;
                    row.PriimtasDarzelis = null;
                    Uow.Requests.Update(row);
                 
                }
                var allPreSchools = Uow.Schools.GetAll().ToList();
                foreach(var school in allPreSchools)
                {
                    if(school.ID==1)
                    {
                        school.PriemimoVaikuKiekis = 2;
                        Uow.Schools.Update(school);
                       
                    }
                    else if(school.ID==2)
                    {
                        school.PriemimoVaikuKiekis = 1;
                        Uow.Schools.Update(school);
                       
                    }
                }
            }catch(Exception ex)
            {
                throw;
            }
        }
        public IList<AlgorithmDataModel> ConstructData(IList<Request> requestList, IRequestUow Uow)
        {
            IList<AlgorithmDataModel> data = new List<AlgorithmDataModel>();
            foreach (var row in requestList)
            {
                var temp = new AlgorithmDataModel();
                temp.Id = row.Id;
                temp.PrasymoPateikimoData = row.PrasymoPateikimoData;
                temp.VaikoId = row.VaikoId;
                temp.VaikoIDNF = row.VaikoIDNF;
                temp.VaikoGimimoData = row.VaikoGimimoData;
                temp.LankymoData = row.LankymoData;
                temp.VaikoSeniunija = row.VaikoSeniunija;
                temp.Prioritetas_DeklaruotasMiestas = row.Prioritetas_DeklaruotasMiestas;
                temp.Prioritetas_3_ar_Daugiau_Vaiku = row.Prioritetas_3_ar_Daugiau_Vaiku;
                temp.Prioritetas_seimosdarbingumoLygis = row.Prioritetas_seimosdarbingumoLygis;
                temp.Prioritetas_auginaTikVienasTevas = row.Prioritetas_auginaTikVienasTevas;

                IList<RequestInfo> GetInfoListById = Uow.RequestInfo.GetAll().ToList().Where(x => x.RequestIdRef == row.Id).ToList().OrderBy(z => z.DarzelioEilesPrioritetas).ToList();

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


                temp.PrioritetuSuma = row.PrioritetuSuma;
                temp.Accepted = row.Accepted;
                temp.PriimtasDarzelis = row.PriimtasDarzelis;
                data.Add(temp);
            }
            return data;
        }
        public void get(IRequestUow Uow)
        {
            var AllPreSchoolRequest = Uow.PreRequestSchool.GetAll().ToList();
            foreach (var preRequest in AllPreSchoolRequest)
            {
                int suma = 0;
                if (preRequest.AtitinkaDarzelioPriskirtaTeritorija == true)
                {
                    suma++;
                }
                if (preRequest.DarzeliLankoBrolysSeserys == true)
                {
                    suma++;
                }
                if (preRequest.TinkamaGrupeDarzelyje == true)
                {
                    suma++;
                }
                PreRequestSchool update = Uow.PreRequestSchool.GetById(preRequest.Id);
                update.DarzelisPrioritetuSuma = suma;
                Uow.PreRequestSchool.Update(update);
            }
            IList<Request> requestList = Uow.Requests.GetAllIncludeRequest().ToList().Where(x => x.Accepted == false && x.LankymoData == LankymoData).ToList();
            IList<AlgorithmDataModel> data = ConstructData(requestList, Uow);
            
            AllRequests = data;

            foreach (var request in AllRequests)
            {
                int suma = 0;
                if (request.Prioritetas_3_ar_Daugiau_Vaiku == true)
                {
                    suma++;
                }
                if (request.Prioritetas_auginaTikVienasTevas == true)
                {
                    suma++;
                }
                if (request.Prioritetas_DeklaruotasMiestas == true)
                {
                    suma++;
                }
                if (request.Prioritetas_seimosdarbingumoLygis == true)
                {
                    suma++;
                }

                Request update = Uow.Requests.GetById(request.Id);
                update.PrioritetuSuma = suma;
                update.Accepted = false;
                update.PreSchoolAccepted = null;
                update.PriimtasDarzelis = null;
                Uow.Requests.Update(update);

                request.PrioritetuSuma = suma;
                request.Accepted = false;
                request.PreSchoolAccepted = null;
                request.PriimtasDarzelis = null;
            }
            AllSchools = Uow.Schools.GetAll().ToList();
            var selected1 = AllRequests.Select(x => x.PasirinktasDarzelis_1).Distinct().ToList();
            var selected2 = AllRequests.Select(x => x.PasirinktasDarzelis_2).Where(x => !selected1.Contains(x)).Distinct().ToList();
            var selected3 = AllRequests.Select(x => x.PasirinktasDarzelis_3).Where(x => !selected1.Contains(x) && !selected2.Contains(x)).Distinct().ToList();
            var selected4 = AllRequests.Select(x => x.PasirinktasDarzelis_4).Where(x => !selected1.Contains(x) && !selected2.Contains(x) && !selected3.Contains(x)).Distinct().ToList();
            var selected5 = AllRequests.Select(x => x.PasirinktasDarzelis_5).Where(x => !selected1.Contains(x) && !selected2.Contains(x) && !selected3.Contains(x) && !selected4.Contains(x)).Distinct().ToList();
            process(selected1, Uow);
            IList<Request> requestList11 = Uow.Requests.GetAllIncludeRequest().ToList();
            IList<AlgorithmDataModel> data11 = ConstructData(requestList11, Uow);
            
            AllRequests = data11.Where(x => x.Accepted == false).ToList();
            if (selected2.Count != 0) { process(selected2, Uow); }
            IList<Request> requestList12 = Uow.Requests.GetAllIncludeRequest().ToList();
            IList<AlgorithmDataModel> data12 = ConstructData(requestList12, Uow);
            
            AllRequests = data12.Where(x => x.Accepted == false).ToList();
            if (selected3.Count != 0) { process(selected3, Uow); }
            IList<Request> requestList13 = Uow.Requests.GetAllIncludeRequest().ToList();
            IList<AlgorithmDataModel> data13 = ConstructData(requestList13, Uow);
            
            AllRequests = data13.Where(x => x.Accepted == false).ToList();
            if (selected4.Count != 0) { process(selected4, Uow); }
            IList<Request> requestList14 = Uow.Requests.GetAllIncludeRequest().ToList();
            IList<AlgorithmDataModel> data14 = ConstructData(requestList14, Uow);
           
            AllRequests = data14.Where(x => x.Accepted == false).ToList();
            if (selected5.Count != 0) { process(selected5, Uow); }
            IList<Request> requestList15 = Uow.Requests.GetAllIncludeRequest().ToList();
            IList<AlgorithmDataModel> data15 = new List<AlgorithmDataModel>();
            foreach (var row in requestList15)
            {
                var temp = new AlgorithmDataModel();
                temp.Id = row.Id;
                temp.PrasymoPateikimoData = row.PrasymoPateikimoData;
                temp.VaikoId = row.VaikoId;
                temp.VaikoIDNF = row.VaikoIDNF;
                temp.VaikoGimimoData = row.VaikoGimimoData;
                temp.LankymoData = row.LankymoData;
                temp.VaikoSeniunija = row.VaikoSeniunija;
                temp.Prioritetas_DeklaruotasMiestas = row.Prioritetas_DeklaruotasMiestas;
                temp.Prioritetas_3_ar_Daugiau_Vaiku = row.Prioritetas_3_ar_Daugiau_Vaiku;
                temp.Prioritetas_seimosdarbingumoLygis = row.Prioritetas_seimosdarbingumoLygis;
                temp.Prioritetas_auginaTikVienasTevas = row.Prioritetas_auginaTikVienasTevas;

                IList<RequestInfo> GetInfoListById = Uow.RequestInfo.GetAll().ToList().Where(x => x.RequestIdRef == row.Id).ToList().OrderBy(z => z.DarzelioEilesPrioritetas).ToList();

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


                temp.PrioritetuSuma = row.PrioritetuSuma;
                temp.Accepted = row.Accepted;
                temp.PriimtasDarzelis = row.PriimtasDarzelis;
                if (row.PriimtasDarzelis.HasValue && row.Accepted)
                {
                    temp.PreSchoolAccepted = Uow.Schools.GetById(row.PriimtasDarzelis.Value);
                }
                data15.Add(temp);
            }
            AllRequests = data15;
            AllRequests = AllRequests.OrderByDescending(p => p.PrioritetuSuma).ToList();
            AllDeclinedRequests = AllRequests.Where(x => x.Accepted == false).ToList();
            AllAcceptedRequests = AllRequests.Where(x => x.Accepted == true).ToList();
        }

        public void process(List<int?> selected, IRequestUow Uow)
        {
            //------------
            if (selected != null)
            {
                for (int w = 0; w < selected.Count; w++)
                {
                    var requestList = Uow.Requests.GetAllIncludeRequest().ToList().Where(x => x.Accepted == false && x.LankymoData == LankymoData).ToList();


                    IList<AlgorithmDataModel> data = ConstructData(requestList, Uow);
                   

                    AllRequests = data;
                    
                    PasirinktasDarzelis = selected[w];
                    AllRequests = AllRequests.OrderByDescending(p => p.PrioritetuSuma).ToList();
                    AllDeclinedRequests = AllRequests;

                    if (PasirinktasDarzelis != null)
                    {
                        var Accepted = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault();
                        AllAcceptedRequests = new List<AlgorithmDataModel>();
                        IList<AlgorithmDataModel> AllRequests1 = AllRequests.Where(o => o.PasirinktasDarzelis_1 == PasirinktasDarzelis).ToList();
                        AllRequests1 = AllRequests1.OrderByDescending(p => p.PrioritetuSuma + p.PreRequestSchool1.DarzelisPrioritetuSuma).ToList();
                        int k = 0;
                        int length = Accepted.PriemimoVaikuKiekis - k;
                        for (var i = 0; i < length; i++)
                        {

                            if (i >= AllRequests1.Count())
                            {
                                break;
                            }
                            if (AllRequests1.Count() == 0)
                            {
                                break;
                            }
                            AllAcceptedRequests.Add(AllRequests1[i]);
                            AllDeclinedRequests.Remove(AllRequests1[i]);
                            k++;
                        }

                        Pre_Schools schoolzz = Uow.Schools.GetById(PasirinktasDarzelis.Value);
                        schoolzz.PriemimoVaikuKiekis = schoolzz.PriemimoVaikuKiekis - k;
                        Uow.Schools.Update(schoolzz);

                        for (int v = 0; v < AllAcceptedRequests.Count; v++)
                        {
                            
                            Request update = Uow.Requests.GetById(AllAcceptedRequests[v].Id);
                            update.Accepted = true;
                            update.PriimtasDarzelis = PasirinktasDarzelis;
                            update.PreSchoolAccepted = schoolzz;
                            //update.PreSchool1 = schoolzz;
                            
                            Uow.Requests.Update(update);
                            AllAcceptedRequests[v].Accepted = true;

                        }

                        IList<AlgorithmDataModel> JoinedRequests = new List<AlgorithmDataModel>();
                        AllDeclinedRequests = AllDeclinedRequests.Where(x => x.PasirinktasDarzelis_1 == PasirinktasDarzelis).ToList();
                        JoinedRequests = AllAcceptedRequests.Concat(AllDeclinedRequests).ToList();
                        int vieta = 1;
                        foreach (var req in JoinedRequests)
                        {
                            if (req.PasirinktasDarzelis_1 == PasirinktasDarzelis)
                            {
                                req.PreRequestSchool1.DarzelioVietaEileje = vieta.ToString();
                                PreRequestSchool update = Uow.PreRequestSchool.GetById(req.PreRequestSchool1.Id);
                                update.DarzelioVietaEileje = vieta.ToString();
                                Uow.PreRequestSchool.Update(update);
                            }
                            vieta++;
                        }
                        DarzelioPavadinimas = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault().Label;

                    }
                }


                for (int w = 0; w < selected.Count; w++)
                {
                    var requestList = Uow.Requests.GetAllIncludeRequest().ToList().Where(x => x.Accepted == false && x.LankymoData == LankymoData).ToList();
                    IList<AlgorithmDataModel> data = ConstructData(requestList, Uow);
                   
                    AllRequests = data;
                    PasirinktasDarzelis = selected[w];
                    
                    AllRequests = AllRequests.OrderByDescending(p => p.PrioritetuSuma).ToList();
                    AllDeclinedRequests = AllRequests;

                    if (PasirinktasDarzelis != null)
                    {
                        var Accepted = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault();
                        AllAcceptedRequests = new List<AlgorithmDataModel>();
                        IList<AlgorithmDataModel> AllRequests1 = AllRequests.Where(o => o.PasirinktasDarzelis_2 == PasirinktasDarzelis && o.Accepted == false).ToList();
                        AllRequests1 = AllRequests1.OrderByDescending(p => p.PrioritetuSuma + p.PreRequestSchool2.DarzelisPrioritetuSuma).ToList();
                        int k = 0;
                        int length = Accepted.PriemimoVaikuKiekis - k;
                        for (var i = 0; i < length; i++)
                        {

                            if (i >= AllRequests1.Count())
                            {
                                break;
                            }
                            if (AllRequests1.Count() == 0)
                            {
                                break;
                            }
                            AllAcceptedRequests.Add(AllRequests1[i]);
                            AllDeclinedRequests.Remove(AllRequests1[i]);
                            k++;
                        }
                        Pre_Schools schoolzz = Uow.Schools.GetById(PasirinktasDarzelis.Value);
                        schoolzz.PriemimoVaikuKiekis = schoolzz.PriemimoVaikuKiekis - k;
                        Uow.Schools.Update(schoolzz);
                        for (int v = 0; v < AllAcceptedRequests.Count; v++)
                        {
                            
                            Request update = Uow.Requests.GetById(AllAcceptedRequests[v].Id);
                            update.Accepted = true;
                            update.PriimtasDarzelis = PasirinktasDarzelis;
                            update.PreSchoolAccepted = schoolzz;
                            
                            Uow.Requests.Update(update);
                            AllAcceptedRequests[v].Accepted = true;
                        }

                        IList<AlgorithmDataModel> JoinedRequests = new List<AlgorithmDataModel>();
                        
                        List<int> IdList = AllAcceptedRequests.Select(x => x.Id).ToList();

                        //
                        var requestList2 = Uow.Requests.GetAllIncludeRequest().ToList();
                        IList<AlgorithmDataModel> data2 = ConstructData(requestList2, Uow);
                        
                        var AllDecRequests = data2.Where(x => x.PasirinktasDarzelis_2 == PasirinktasDarzelis && !IdList.Contains(x.Id) && x.LankymoData == LankymoData).ToList();
                        var AllacceRequests = AllAcceptedRequests.Concat(AllDecRequests).ToList();
                        //
                        AllDeclinedRequests = AllDecRequests;
                        JoinedRequests = AllacceRequests;
                        int vieta = data2.Where(x => x.PasirinktasDarzelis_1 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count + 1;
                        foreach (var req in JoinedRequests)
                        {
                            if (req.PasirinktasDarzelis_2 == PasirinktasDarzelis)
                            {
                                req.PreRequestSchool2.DarzelioVietaEileje = vieta.ToString();
                                PreRequestSchool update = Uow.PreRequestSchool.GetById(req.PreRequestSchool2.Id);
                                update.DarzelioVietaEileje = vieta.ToString();
                                Uow.PreRequestSchool.Update(update);
                            }
                            vieta++;
                        }
                        DarzelioPavadinimas = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault().Label;
                    }
                }

                for (int w = 0; w < selected.Count; w++)
                {
                    PasirinktasDarzelis = selected[w];
                    
                        var requestList = Uow.Requests.GetAllIncludeRequest().ToList().Where(x => x.Accepted == false && x.LankymoData == LankymoData).ToList();

                    IList<AlgorithmDataModel> data = ConstructData(requestList, Uow);
                   
                    AllRequests = data;
                   
                    AllRequests = AllRequests.OrderByDescending(p => p.PrioritetuSuma).ToList();
                    AllDeclinedRequests = AllRequests;

                    if (PasirinktasDarzelis != null)
                    {
                        var Accepted = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault();
                        AllAcceptedRequests = new List<AlgorithmDataModel>();
                        IList<AlgorithmDataModel> AllRequests1 = AllRequests.Where(o => o.PasirinktasDarzelis_3 == PasirinktasDarzelis && o.Accepted == false).ToList();
                        AllRequests1 = AllRequests1.OrderByDescending(p => p.PrioritetuSuma + p.PreRequestSchool3.DarzelisPrioritetuSuma).ToList();
                        int k = 0;
                        int length = Accepted.PriemimoVaikuKiekis - k;
                        for (var i = 0; i < length; i++)
                        {

                            if (i >= AllRequests1.Count())
                            {
                                break;
                            }
                            if (AllRequests1.Count() == 0)
                            {
                                break;
                            }
                            AllAcceptedRequests.Add(AllRequests1[i]);
                            AllDeclinedRequests.Remove(AllRequests1[i]);
                            k++;
                        }
                        Pre_Schools schoolzz = Uow.Schools.GetById(PasirinktasDarzelis.Value);
                        schoolzz.PriemimoVaikuKiekis = schoolzz.PriemimoVaikuKiekis - k;
                        Uow.Schools.Update(schoolzz);
                        for (int v = 0; v < AllAcceptedRequests.Count; v++)
                        {
                           
                            Request update = Uow.Requests.GetById(AllAcceptedRequests[v].Id);
                            update.Accepted = true;
                            update.PriimtasDarzelis = PasirinktasDarzelis;
                            update.PreSchoolAccepted = schoolzz;
                            //update.PreSchool3 = schoolzz;
                            Uow.Requests.Update(update);
                            AllAcceptedRequests[v].Accepted = true;
                        }

                        IList<AlgorithmDataModel> JoinedRequests = new List<AlgorithmDataModel>();
                       
                        List<int> IdList = AllAcceptedRequests.Select(x => x.Id).ToList();

                        var requestList2 = Uow.Requests.GetAllIncludeRequest().ToList();
                        IList<AlgorithmDataModel> data3 = ConstructData(requestList2, Uow);
                        
                        AllDeclinedRequests = data3.Where(x => x.PasirinktasDarzelis_3 == PasirinktasDarzelis && !IdList.Contains(x.Id) && x.LankymoData == LankymoData).ToList();
                        JoinedRequests = AllAcceptedRequests.Concat(AllDeclinedRequests).ToList();
                        var kiekis = data3.Where(x => x.PasirinktasDarzelis_1 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count;
                        int vieta = kiekis + data3.Where(x => x.PasirinktasDarzelis_2 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count + 1;
                        foreach (var req in JoinedRequests)
                        {
                            if (req.PasirinktasDarzelis_3 == PasirinktasDarzelis)
                            {
                                req.PreRequestSchool3.DarzelioVietaEileje = vieta.ToString();
                                PreRequestSchool update = Uow.PreRequestSchool.GetById(req.PreRequestSchool3.Id);
                                update.DarzelioVietaEileje = vieta.ToString();
                                Uow.PreRequestSchool.Update(update);
                            }
                            vieta++;
                        }
                        DarzelioPavadinimas = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault().Label;
                    }
                }
                //

                for (int w = 0; w < selected.Count; w++)
                {
                    PasirinktasDarzelis = selected[w];

                    var requestList = Uow.Requests.GetAllIncludeRequest().ToList();
                    IList<AlgorithmDataModel> data4 = ConstructData(requestList, Uow);
                    
                    AllRequests = data4.Where(x => x.Accepted == false && x.LankymoData == LankymoData).ToList();
                    
                    AllRequests = AllRequests.OrderByDescending(p => p.PrioritetuSuma).ToList();
                    AllDeclinedRequests = AllRequests;

                    if (PasirinktasDarzelis != null)
                    {
                        var Accepted = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault();
                        AllAcceptedRequests = new List<AlgorithmDataModel>();
                        IList<AlgorithmDataModel> AllRequests1 = AllRequests.Where(o => o.PasirinktasDarzelis_4 == PasirinktasDarzelis && o.Accepted == false).ToList();
                        AllRequests1 = AllRequests1.OrderByDescending(p => p.PrioritetuSuma + p.PreRequestSchool4.DarzelisPrioritetuSuma).ToList();
                        int k = 0;
                        int length = Accepted.PriemimoVaikuKiekis - k;
                        for (var i = 0; i < length; i++)
                        {

                            if (i >= AllRequests1.Count())
                            {
                                break;
                            }
                            if (AllRequests1.Count() == 0)
                            {
                                break;
                            }
                            AllAcceptedRequests.Add(AllRequests1[i]);
                            AllDeclinedRequests.Remove(AllRequests1[i]);
                            k++;
                        }
                        Pre_Schools schoolzz = Uow.Schools.GetById(PasirinktasDarzelis.Value);
                        schoolzz.PriemimoVaikuKiekis = schoolzz.PriemimoVaikuKiekis - k;
                        Uow.Schools.Update(schoolzz);
                        for (int v = 0; v < AllAcceptedRequests.Count; v++)
                        {
                            
                            Request update = Uow.Requests.GetById(AllAcceptedRequests[v].Id);
                            update.Accepted = true;
                            update.PriimtasDarzelis = PasirinktasDarzelis;
                            update.PreSchoolAccepted = schoolzz;
                            //update.PreSchool4 = schoolzz;
                            Uow.Requests.Update(update);
                            AllAcceptedRequests[v].Accepted = true;
                        }

                        IList<AlgorithmDataModel> JoinedRequests = new List<AlgorithmDataModel>();
                        
                        List<int> IdList = AllAcceptedRequests.Select(x => x.Id).ToList();
                        //---

                        var requestList3 = Uow.Requests.GetAllIncludeRequest().ToList();
                        IList<AlgorithmDataModel> data5 = ConstructData(requestList3, Uow);
                        
                        AllDeclinedRequests = data5.Where(x => x.PasirinktasDarzelis_4 == PasirinktasDarzelis && !IdList.Contains(x.Id) && x.LankymoData == LankymoData).ToList();

                        JoinedRequests = AllAcceptedRequests.Concat(AllDeclinedRequests).ToList();
                        var kiekis = data5.Where(x => x.PasirinktasDarzelis_1 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count;
                        kiekis += data5.Where(x => x.PasirinktasDarzelis_2 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count;
                        int vieta = kiekis + data5.ToList().Where(x => x.PasirinktasDarzelis_3 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count + 1;
                        foreach (var req in JoinedRequests)
                        {
                            if (req.PasirinktasDarzelis_4 == PasirinktasDarzelis)
                            {
                                req.PreRequestSchool4.DarzelioVietaEileje = vieta.ToString();
                                PreRequestSchool update = Uow.PreRequestSchool.GetById(req.PreRequestSchool4.Id);
                                update.DarzelioVietaEileje = vieta.ToString();
                                Uow.PreRequestSchool.Update(update);
                            }
                            vieta++;
                        }
                        DarzelioPavadinimas = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault().Label;
                    }
                }
                //

                for (int w = 0; w < selected.Count; w++)
                {
                    PasirinktasDarzelis = selected[w];
                    
                    //-
                    var requestList4 = Uow.Requests.GetAllIncludeRequest().ToList();
                    IList<AlgorithmDataModel> data6 = ConstructData(requestList4, Uow);
                    
                    AllRequests = data6.Where(x => x.Accepted == false && x.LankymoData == LankymoData).ToList();
                    
                    AllRequests = AllRequests.OrderByDescending(p => p.PrioritetuSuma).ToList();
                    AllDeclinedRequests = AllRequests;

                    if (PasirinktasDarzelis != null)
                    {
                        var Accepted = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault();
                        AllAcceptedRequests = new List<AlgorithmDataModel>();
                        IList<AlgorithmDataModel> AllRequests1 = AllRequests.Where(o => o.PasirinktasDarzelis_5 == PasirinktasDarzelis && o.Accepted == false).ToList();
                        AllRequests1 = AllRequests1.OrderByDescending(p => p.PrioritetuSuma + p.PreRequestSchool5.DarzelisPrioritetuSuma).ToList();
                        int k = 0;
                        int length = Accepted.PriemimoVaikuKiekis - k;
                        for (var i = 0; i < length; i++)
                        {

                            if (i >= AllRequests1.Count())
                            {
                                break;
                            }
                            if (AllRequests1.Count() == 0)
                            {
                                break;
                            }
                            AllAcceptedRequests.Add(AllRequests1[i]);
                            AllDeclinedRequests.Remove(AllRequests1[i]);
                            k++;
                        }
                        Pre_Schools schoolzz = Uow.Schools.GetById(PasirinktasDarzelis.Value);
                        schoolzz.PriemimoVaikuKiekis = schoolzz.PriemimoVaikuKiekis - k;
                        Uow.Schools.Update(schoolzz);
                        for (int v = 0; v < AllAcceptedRequests.Count; v++)
                        {
                            
                            Request update = Uow.Requests.GetById(AllAcceptedRequests[v].Id);
                            update.Accepted = true;
                            update.PriimtasDarzelis = PasirinktasDarzelis;
                            update.PreSchoolAccepted = schoolzz;
                            //update.PreSchool5 = schoolzz;
                            Uow.Requests.Update(update);
                            AllAcceptedRequests[v].Accepted = true;
                        }

                        IList<AlgorithmDataModel> JoinedRequests = new List<AlgorithmDataModel>();
                        //AllDeclinedRequests = AllDeclinedRequests.Where(x => x.PasirinktasDarzelis_5 == PasirinktasDarzelis).ToList();
                        //AllDeclinedRequests = Uow.Requests.GetAllIncludeRequest().ToList().Where(x => x.PasirinktasDarzelis_5 == PasirinktasDarzelis && !AllAcceptedRequests.Contains(x)).ToList();
                        List<int> IdList = AllAcceptedRequests.Select(x => x.Id).ToList();

                        var requestList5 = Uow.Requests.GetAllIncludeRequest().ToList();
                        IList<AlgorithmDataModel> data7 = ConstructData(requestList5, Uow);
                        
                        AllDeclinedRequests = data7.Where(x => x.PasirinktasDarzelis_5 == PasirinktasDarzelis && !IdList.Contains(x.Id)).ToList();

                        JoinedRequests = AllAcceptedRequests.Concat(AllDeclinedRequests).ToList();
                        var kiekis = data7.Where(x => x.PasirinktasDarzelis_1 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count;
                        kiekis += data7.Where(x => x.PasirinktasDarzelis_2 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count;
                        kiekis += data7.Where(x => x.PasirinktasDarzelis_3 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count;
                        int vieta = kiekis + data7.Where(x => x.PasirinktasDarzelis_4 == PasirinktasDarzelis && x.LankymoData == LankymoData).ToList().Count + 1;
                        foreach (var req in JoinedRequests)
                        {
                            if (req.PasirinktasDarzelis_5 == PasirinktasDarzelis)
                            {
                                req.PreRequestSchool5.DarzelioVietaEileje = vieta.ToString();
                                PreRequestSchool update = Uow.PreRequestSchool.GetById(req.PreRequestSchool5.Id);
                                update.DarzelioVietaEileje = vieta.ToString();
                                Uow.PreRequestSchool.Update(update);
                            }
                            vieta++;
                        }
                        DarzelioPavadinimas = AllSchools.Where(x => x.ID == PasirinktasDarzelis).FirstOrDefault().Label;
                    }
                }
            }
        }
    }
}
