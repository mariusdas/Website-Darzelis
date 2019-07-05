using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Darzelis.Web.Models
{
    public class AlgorithmDataModel
    {
            public int Id { get; set; }
            public DateTime PrasymoPateikimoData { get; set; }
            public int? VaikoId { get; set; }
            public User VaikoIDNF { get; set; }
            public DateTime VaikoGimimoData { get; set; }
            public DateTime LankymoData { get; set; }
            public string VaikoSeniunija { get; set; }
            public bool Prioritetas_DeklaruotasMiestas { get; set; }
            public bool Prioritetas_3_ar_Daugiau_Vaiku { get; set; }
            public bool Prioritetas_seimosdarbingumoLygis { get; set; }
            public bool Prioritetas_auginaTikVienasTevas { get; set; }

            public int? PasirinktasDarzelis_1 { get; set; }
            
            public Pre_Schools PreSchool1 { get; set; }
            //00000
            public int? UzpildytasDarzelis_1 { get; set; }
            
            public PreRequestSchool PreRequestSchool1 { get; set; }
            

            public int? PasirinktasDarzelis_2 { get; set; }
            public Pre_Schools PreSchool2 { get; set; }
            //00000
            public int? UzpildytasDarzelis_2 { get; set; }
            public PreRequestSchool PreRequestSchool2 { get; set; }
           

            //3
            public int? PasirinktasDarzelis_3 { get; set; }
            public Pre_Schools PreSchool3 { get; set; }
            //00000
            public int? UzpildytasDarzelis_3 { get; set; }
            public PreRequestSchool PreRequestSchool3 { get; set; }
            
            //4
            public int? PasirinktasDarzelis_4 { get; set; }
            public Pre_Schools PreSchool4 { get; set; }
            //00000
            public int? UzpildytasDarzelis_4 { get; set; }
           
            public PreRequestSchool PreRequestSchool4 { get; set; }


            
            //5
            public int? PasirinktasDarzelis_5 { get; set; }
            public Pre_Schools PreSchool5 { get; set; }
            //000
            public int? UzpildytasDarzelis_5 { get; set; }
            public PreRequestSchool PreRequestSchool5 { get; set; }
            public int? PrioritetuSuma { get; set; }
            public bool Accepted { get; set; }
            public int? PriimtasDarzelis { get; set; }
         
            public Pre_Schools PreSchoolAccepted { get; set; }

        
    }
}