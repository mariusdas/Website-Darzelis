using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darzelis.Models.Entities
{
    public class PreRequestSchool
    {
        public int Id { get; set; }
        public string DarzelioVietaEileje { get; set; }
        public string Darzelio_seniūnija { get; set; }
        public string DarzelioGrupesUgdymojiKalba{ get; set; }
        public string DarzelioGrupesUgdymoMetodika{ get; set; }
        public string DarzelioGrupesTipas { get; set; }
        public string DarzelioAmziausIntervalas { get; set; }
        public bool AtitinkaDarzelioPriskirtaTeritorija { get; set; }
        public bool DarzeliLankoBrolysSeserys { get; set; }
        public bool TinkamaGrupeDarzelyje { get; set; }
        public int? DarzelisPrioritetuSuma { get; set; }
    }
}
