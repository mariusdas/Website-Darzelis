using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darzelis.Web.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public DateTime PrasymoPateikimoData { get; set; }
        public int? VaikoId { get; set; }
     
        public DateTime VaikoGimimoData { get; set; }
        public DateTime LankymoData { get; set; }
        public string VaikoSeniunija { get; set; }
        public bool Prioritetas_DeklaruotasMiestas { get; set; }
        public bool Prioritetas_3_ar_Daugiau_Vaiku { get; set; }
        public bool Prioritetas_seimosdarbingumoLygis { get; set; }
        public bool Prioritetas_auginaTikVienasTevas { get; set; }
        public int? PasirinktasDarzelis_1 { get; set; }
        public int? UzpildytasDarzelis_1 { get; set; }

        public string DarzelioVietaEileje_1 { get; set; }
        public string Darzelio_seniūnija_1 { get; set; }
        public string DarzelioGrupesUgdymojiKalba_1 { get; set; }
        public string DarzelioGrupesUgdymoMetodika_1 { get; set; }
        public string DarzelioGrupesTipas_1 { get; set; }
        public string DarzelioAmziausIntervalas_1 { get; set; }
        public bool AtitinkaDarzelioPriskirtaTeritorija_1 { get; set; }
        public bool DarzeliLankoBrolysSeserys_1 { get; set; }
        public bool TinkamaGrupeDarzelyje_1 { get; set; }

        public int? PasirinktasDarzelis_2 { get; set; }
     
        //00000
        public int? UzpildytasDarzelis_2 { get; set; }

        public string DarzelioVietaEileje_2 { get; set; }
        public string Darzelio_seniūnija_2 { get; set; }
        public string DarzelioGrupesUgdymojiKalba_2 { get; set; }
        public string DarzelioGrupesUgdymoMetodika_2 { get; set; }
        public string DarzelioGrupesTipas_2 { get; set; }
        public string DarzelioAmziausIntervalas_2 { get; set; }
        public bool AtitinkaDarzelioPriskirtaTeritorija_2 { get; set; }
        public bool DarzeliLankoBrolysSeserys_2 { get; set; }
        public bool TinkamaGrupeDarzelyje_2 { get; set; }

        //3
        public int? PasirinktasDarzelis_3 { get; set; }
    
        //00000
        public int? UzpildytasDarzelis_3 { get; set; }

        public string DarzelioVietaEileje_3 { get; set; }
        public string Darzelio_seniūnija_3 { get; set; }
        public string DarzelioGrupesUgdymojiKalba_3 { get; set; }
        public string DarzelioGrupesUgdymoMetodika_3 { get; set; }
        public string DarzelioGrupesTipas_3 { get; set; }
        public string DarzelioAmziausIntervalas_3 { get; set; }
        public bool AtitinkaDarzelioPriskirtaTeritorija_3 { get; set; }
        public bool DarzeliLankoBrolysSeserys_3 { get; set; }
        public bool TinkamaGrupeDarzelyje_3 { get; set; }
        //4
        public int? PasirinktasDarzelis_4 { get; set; }
       
        //00000
        public int? UzpildytasDarzelis_4 { get; set; }


        public string DarzelioVietaEileje_4 { get; set; }
        public string Darzelio_seniūnija_4 { get; set; }
        public string DarzelioGrupesUgdymojiKalba_4 { get; set; }
        public string DarzelioGrupesUgdymoMetodika_4 { get; set; }
        public string DarzelioGrupesTipas_4 { get; set; }
        public string DarzelioAmziausIntervalas_4 { get; set; }
        public bool AtitinkaDarzelioPriskirtaTeritorija_4 { get; set; }
        public bool DarzeliLankoBrolysSeserys_4 { get; set; }
        public bool TinkamaGrupeDarzelyje_4 { get; set; }
        //5
        public int? PasirinktasDarzelis_5 { get; set; }
      
        //000
        public int? UzpildytasDarzelis_5 { get; set; }


        public string DarzelioVietaEileje_5 { get; set; }
        public string Darzelio_seniūnija_5 { get; set; }
        public string DarzelioGrupesUgdymojiKalba_5 { get; set; }
        public string DarzelioGrupesUgdymoMetodika_5 { get; set; }
        public string DarzelioGrupesTipas_5 { get; set; }
        public string DarzelioAmziausIntervalas_5 { get; set; }
        public bool AtitinkaDarzelioPriskirtaTeritorija_5 { get; set; }
        public bool DarzeliLankoBrolysSeserys_5 { get; set; }
        public bool TinkamaGrupeDarzelyje_5 { get; set; }

        public string ErrorMessage { get; set; }
    }
}